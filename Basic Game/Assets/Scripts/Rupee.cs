using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rupee" , menuName = "Rupee")] // adds rupee in the unity menu
public class Rupee : ScriptableObject {
    public int value; // points that each rupee adds
    public Sprite sprite; // specific rupee sprite
}