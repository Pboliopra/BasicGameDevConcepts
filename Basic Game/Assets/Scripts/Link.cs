using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Link : MonoBehaviour
{
    [SerializeField] float jump;
    private string currentAnimaton;
    private Animator animator;
    private Rigidbody2D rigid2D;
    [SerializeField] AudioClip clip_jump;
    [SerializeField] AudioClip clip_hurt;

    private AudioSource audioSource;
    private bool jumpSignal;
    private bool isJumping;
    private Vector3 startingPos;
    private bool canPlaySFX;
    
    // Start is called before the first frame update
    void Start() {
        rigid2D = GetComponent<Rigidbody2D>();
        animator = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip_jump;
        startingPos = transform.parent.position;
        canPlaySFX = true;
        isJumping = false;
    }

    // Update is called once per frame
    void Update() {
        Idle();
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!isJumping) {
                isJumping = true;
                rigid2D.AddForce(new Vector2(0, jump));
                ChangeAnimationState("jump");
                PlayJumpSound(canPlaySFX);
            }
        }
    }

    void Idle() {
        if(Input.anyKey == false && isJumping == false)
           ChangeAnimationState("walk"); 
    }

    void ChangeAnimationState(string newAnimation) {
        /* 
        This function switches the animations 
        smoothly and returns them upon inputs
        */
        if (currentAnimaton == newAnimation) return;
        animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    void PlayJumpSound(bool canPlayJumpSound) {
        if (canPlayJumpSound)
            audioSource.Play();
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Floor") && isJumping) {
            isJumping = false;
        }
    }

    // private void OnCollisionExit2D(Collision2D other){
    //     if (other.gameObject.CompareTag("Floor"))
    //         isJumping = true;  
    // }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Damage")) {
            // Reset jump (my boy Link died)
            isJumping = false;

            // Start Death Routine Asynchronously (this sounds depressing)
            StartCoroutine(death());
            
        }

        else if (other.gameObject.CompareTag("Rupee")) {

        }
    }

    IEnumerator death() {        
        audioSource.clip = clip_hurt;
        canPlaySFX = false;
        audioSource.Play();
        
        Time.timeScale = 0f;
        yield return new WaitWhile (()=> audioSource.isPlaying);
        Time.timeScale = 1f;
        transform.parent.position = startingPos;
        
        // When hurt sound finishes reset audio clip and allow jump sound to play
        audioSource.clip = clip_jump;
        canPlaySFX = true;
    }
}