using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rupee" , menuName = "Rupee")]
public class Rupee : ScriptableObject {
    [SerializeField] int value;
    public Sprite sprite;
    public int GetValue(){
        return value;
    }
}