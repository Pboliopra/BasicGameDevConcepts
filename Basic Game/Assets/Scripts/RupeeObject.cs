using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeObject : MonoBehaviour, IScoringObject {
    [SerializeField] Rupee rupee; // declares rupee object
    [SerializeField] SpriteRenderer spriteRenderer; // calls the sprite renderer of the rupee

    private int value; // holds the points of a rupee

    // Sets the value and sprite to be rendered when the game starts
    void Start() {
        value = rupee.value;
        spriteRenderer.sprite = rupee.sprite;
    }
    // Gets the points of each rupee
    public int GetValue() {
        return value;
    }
}
