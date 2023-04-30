using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 move;
    [SerializeField] float speed;
    // Declares movement to be 1 on x
    void Start() {
        move = new Vector3(1, 0, 0);
        // speed = 3;
    }

    // Updates position
    void Update() {
        transform.Translate(move * speed * Time.deltaTime);
    }
}
