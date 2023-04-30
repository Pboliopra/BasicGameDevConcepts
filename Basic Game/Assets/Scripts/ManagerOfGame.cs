using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerOfGame : MonoBehaviour {
    [SerializeField] GameObject[] enemies;
    public void Reset(){
        foreach (var enemy in enemies)
           enemy.gameObject.GetComponent<IEnemy>().Reset();
    }
}