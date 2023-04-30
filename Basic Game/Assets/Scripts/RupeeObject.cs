using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeObject : MonoBehaviour, IScoringObject {
    [SerializeField] Rupee rupee;
    [SerializeField] SpriteRenderer spriteRenderer;

    private int value;

    void Start() {
        value = rupee.value;
        spriteRenderer.sprite = rupee.sprite;
    }

    public int GetValue() {
        return value;
    }
}
