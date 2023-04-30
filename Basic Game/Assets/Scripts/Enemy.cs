using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private Vector3 startingPos; // placeholder for initial position
    // Upon start its position becomes its initial one
    void Start() {
        startingPos = transform.position;
    }
}