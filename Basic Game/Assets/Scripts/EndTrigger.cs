using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {
    [SerializeField] GameManager gameManager;
    private bool firstCollide; // checks for the first touch of the complete flag
    private Collider2D flag;

    void Start(){
        firstCollide = false;
        flag = GetComponent<Collider2D>();
        flag.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (firstCollide) return;
        gameManager.CompleteLevel();
        flag.enabled = false;
    }
}
