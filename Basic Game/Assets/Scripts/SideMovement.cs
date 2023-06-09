using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : MonoBehaviour, IEnemy {
    [SerializeField] float amplitude;
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;
    private SpriteRenderer sprite; // creates a sprite rerer object
    float angle;
    float prev; // previous sine value (last frame)
    [SerializeField] bool isFlipped; // flip boolean
    private Vector3 origin; 
    private bool original; // Saves original value of the flip boolean

    // sets initial position as 0, prev as 0 and flip boolean as something given in unity
    void Start() {
        origin = transform.position;
        sprite = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        prev = 0;
        sprite.flipX = isFlipped;
        original = isFlipped;
    }

    // Updates position of the ghost which is described by a sine function
    void Update() {
        float sine = Mathf.Sin(angle);
        if ((isFlipped && sine - prev < 0) || (!isFlipped && sine - prev > 0)) {
            isFlipped = !isFlipped;
            sprite.flipX = !sprite.flipX;
        } 

        transform.position = origin + direction * sine * amplitude;
        angle += speed * Time.deltaTime;
        
    }
    // Implentation of reset function IEnemy interface to place enemies in their original position
    public void Reset(){
        transform.position = origin;
        prev = 0;
        isFlipped = original;
        angle = 0;
    }
}
