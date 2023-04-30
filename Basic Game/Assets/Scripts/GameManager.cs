using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    [SerializeField] GameObject[] enemies;
    [SerializeField] GameObject scoreUI;
    [SerializeField] GameObject endScreen;
    [SerializeField] TMP_Text scoreDisplay;
    [SerializeField] Link player;

    [SerializeField] AudioSource music;
    [SerializeField] AudioSource victorySound;

    public void CompleteLevel() {
        scoreUI.SetActive(false);
        endScreen.SetActive(true);
        scoreDisplay.text = " You collected: $" + player.GetCash();
        music.Pause();
        StartCoroutine(PlayVictorySound());
    }
    public void Reset(){
        foreach (var enemy in enemies)
           enemy.gameObject.GetComponent<IEnemy>().Reset();
    }

    IEnumerator PlayVictorySound() {
        victorySound.Play();
        Time.timeScale = 0;
        yield return new WaitWhile (()=> victorySound.isPlaying);
        Time.timeScale = 1;
        Destroy(player);
    }
}