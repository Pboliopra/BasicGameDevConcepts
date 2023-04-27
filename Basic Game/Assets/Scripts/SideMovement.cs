using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMovement : MonoBehaviour
{
    [SerializeField] float amplitude;
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    private SpriteRenderer sprite;


    float angle;
    float prev;

    [SerializeField] bool sineIsIncreasing;
    private Vector3 origin;
    // Start is called before the first frame update
    void Start() {
        origin = transform.position;
        sprite = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        prev = 0;
        sprite.flipX = sineIsIncreasing;
    }

    // Update is called once per frame
    void Update() {
        float sine = Mathf.Sin(angle);
        if ((sineIsIncreasing && sine - prev < 0) || (!sineIsIncreasing && sine - prev > 0)) {
            sineIsIncreasing = !sineIsIncreasing;
            sprite.flipX = !sprite.flipX;
        } 

        transform.position = origin + direction * sine * amplitude;
        angle += speed * Time.deltaTime;
        
    }
}
