using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private Vector3 startingPos;

    void Start() {
        startingPos = transform.position;
    }
}