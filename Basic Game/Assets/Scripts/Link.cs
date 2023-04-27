using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Link : MonoBehaviour
{
    [SerializeField] float speed;
    private string currentAnimaton;
    private Animator animator;
    private Rigidbody2D ridig2D;
    private bool isJumpPressed;
    private float jumpForce = 850;
    private bool isGrounded;
    private int groundMask;
    
    // Start is called before the first frame update
    void Start()
    {
        ridig2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundMask = 1 << LayerMask.NameToLayer("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        Idle();
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            isJumpPressed = true;
        }
    }

    void FixedUpdate(){
        //Check if player is stepping on ground
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.1f, groundMask); 
        if (hit.collider != null){
            isGrounded = true;   
        }
        else{
            isGrounded = false;
        }


        //Check if trying to jump 
        if (isJumpPressed && isGrounded)
        {
            ridig2D.AddForce(new Vector2(0, jumpForce));
            isJumpPressed = false;
            ChangeAnimationState("jump");
        }
    }

    void Idle(){
        if(Input.anyKey == false){
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
}
