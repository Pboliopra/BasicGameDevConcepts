using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    [SerializeField] float jump;
    private string currentAnimaton;
    private Animator animator;
    private Rigidbody2D rigid2D;
    private AudioSource audioSource_jump;
    private AudioSource audioSource_hurt;
    private bool isJumping;
    private bool hasVerticalVelocity;
    private bool isPlaying;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        audioSource_jump = this.gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        audioSource_hurt = GetComponent<AudioSource>();
        // jump = 520;
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        Idle();
        //Check if trying to jump 
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rigid2D.AddForce(new Vector2(0, jump));
            ChangeAnimationState("jump");
            isPlaying = true;
            ChangeSound(audioSource_jump, isPlaying);
        }
    }

    void Idle(){
        if(Input.anyKey == false && isJumping == false){
           ChangeAnimationState("walk"); 
        }
    }

    void ChangeAnimationState(string newAnimation){
        /* 
        This function switches the animations 
        smoothly and returns them upon inputs
        */
        if (currentAnimaton == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    void ChangeSound(AudioSource audioSource, bool isPlaying){
        if (isPlaying)
            {
               audioSource_jump.Play();
               isPlaying = false; 
            }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Floor")){
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other){
        if (other.gameObject.CompareTag("Floor")) {
            isJumping = true;
            isPlaying = true;
            ChangeSound(audioSource_hurt, isPlaying);
        }   
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Damage")) {
            isPlaying = true;
            ChangeSound(audioSource_hurt, isPlaying);
        }
    }
}