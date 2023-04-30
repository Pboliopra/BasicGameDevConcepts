using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Link : MonoBehaviour{
    [SerializeField] float jumpForce;
    private string currentAnimaton; // Used to check if changing animation is required
    private Animator animator;
    private Rigidbody2D rigid2D; // Used to add forces

    // SFXs
    [SerializeField] AudioClip clip_jump;
    [SerializeField] AudioClip clip_hurt;
    private AudioSource audioSource; // References Link's audio source
    private bool canPlaySFX; // Checks if Link is not crying (playing hurt sound)
    private bool isJumping; // Checks if Link is already jumping
    private Vector3 startingPos; // Starting position of the parent object (cotains the camera)

    [SerializeField] TMP_Text scoreUI;
    private int cash; // Thy money == Score

    private Collider2D collisionMemo;
    
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
        if (Input.GetKey(KeyCode.Space) && !isJumping)
            Jump();
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
        currentAnimaton = newAnimation;
        animator.Play(newAnimation);
    }

    // Jump routine: has to block further jumps, adds a vertical force and plays SFX if possible
    void Jump() {
        isJumping = true;
        rigid2D.AddForce(new Vector2(0, jumpForce));
        ChangeAnimationState("jump");
        PlayJumpSound(canPlaySFX);
    }

    // Plays the jump sound if and only if jump sound can be played
    void PlayJumpSound(bool canPlayJumpSound) {
        if (canPlayJumpSound)
            audioSource.Play();
    }

    // Check collision and trigger events
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Floor") && isJumping) {
            isJumping = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (collisionMemo == other) return;

        if (other.gameObject.CompareTag("Damage")) {
            // Start Death Routine Asynchronously (this sounds depressing)
            StartCoroutine(death());
            
        }
        else if (other.gameObject.CompareTag("Rupee")) {
            IScoringObject rupee = other.gameObject.GetComponent<IScoringObject>();
            Destroy(other.gameObject);
            cash += rupee.GetValue();
            scoreUI.text = " Cash: " + cash; 
        }
        collisionMemo = other;
    }

    IEnumerator death() {        
        audioSource.clip = clip_hurt;
        canPlaySFX = false;
        audioSource.Play();
        scoreUI.text = " Cash: 0"; 
        // When Link dies: freeze time, wait for sound to end on the background and then unfreeze time
        Time.timeScale = 0f;
        yield return new WaitWhile (()=> audioSource.isPlaying);
        Time.timeScale = 1f;

        // Reset velocity and position
        rigid2D.velocity = Vector3.zero;
        transform.parent.position = startingPos;
        
        // When hurt sound finishes reset audio clip and allow jump sound to play
        audioSource.clip = clip_jump;
        canPlaySFX = true;
    }
}