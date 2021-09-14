using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeBite : MonoBehaviour
{
    public Color currentColor;
    public float faverDuration;
    private float actualFaverDuration;
    private int diamondQueue;
    private int score = 0, dimonds = 0;
    private bool isFaverOn = false;

    void Start()
    {
        GameEventsSystem.current.onSnakeBite += Bite;
        GameEventsSystem.current.onColorChangeTriggerEnter += ChangeColor;
    }

    private void Update() {
        if(isFaverOn) {
            actualFaverDuration -= Time.deltaTime;
            
            if(actualFaverDuration < 0)
                DisableFaver();
        }
    }

    private void Bite(int id, Color color) {
        if (isFaverOn) {
            EatCurrentColor();
        } else {
            if(color == Color.diamond) {
                EatDiamond();
            }
            else if (color == currentColor) {
                EatCurrentColor();
            }
            else {
                Restart();
            }
        }
    }

    private void ChangeColor(Color color) {
        currentColor = color;
    }

    private void EatDiamond() {
        diamondQueue++;
        if(diamondQueue == 3) {
            diamondQueue = 0;
            ActivateFaver();
        }

        dimonds++;
        GameEventsSystem.current.ScoreUpdate(dimonds, score);
    }

    private void ActivateFaver() {
        isFaverOn = true;
        actualFaverDuration = faverDuration;
        GameEventsSystem.current.FaverStart();
    }

    private void DisableFaver() {
        isFaverOn = false;
        GameEventsSystem.current.FaverEnd();
    }

    private void EatCurrentColor() {
        diamondQueue = 0;
        score++;

        GameEventsSystem.current.ScoreUpdate(dimonds, score);
    }

    private void Restart() {
        SceneManager.LoadScene("SampleScene");        
    }
}
