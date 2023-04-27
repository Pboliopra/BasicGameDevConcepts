using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertEnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;
    private SpriteRenderer sprite;
    private Vector3 origin;
    // Start is called before the first frame update
    void Start()
    {
        origin = transform.position;
        sprite = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = origin + direction * e;
    }
}
