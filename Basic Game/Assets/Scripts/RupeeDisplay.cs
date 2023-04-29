using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RupeeDisplay : MonoBehaviour {
    [SerializeField] Rupee rupee;
    [SerializeField] SpriteRenderer spriteRenderer;

    private int value;

    void Start() {
        value = rupee.GetValue();
        spriteRenderer.sprite = rupee.sprite;
    }
}
