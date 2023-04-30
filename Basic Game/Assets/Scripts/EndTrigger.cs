using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour {
    [SerializeField] ManagerOfGame gameManager;

    private void OnTriggerEnter2D(Collider2D other) {
        gameManager.CompleteLevel();
    }
}
