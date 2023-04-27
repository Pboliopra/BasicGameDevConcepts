using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 move;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        move = new Vector3(1, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(move * speed * Time.deltaTime);
    }
}