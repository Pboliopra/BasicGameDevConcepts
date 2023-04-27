using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMonvement : MonoBehaviour
{
    [SerializeField] float amplitude;
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    float angle;
    Vector3 origin;
    // Start is called before the first frame update
    void Start() {
        origin = transform.position;
    }

    // Update is called once per frame
    void Update() {
        transform.position = origin + direction * Mathf.Sin(angle) * amplitude;
        angle += speed * Time.deltaTime;
    }
}
