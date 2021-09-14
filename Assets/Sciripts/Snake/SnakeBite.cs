using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeBite : MonoBehaviour
{
    public Color currentColor;
    public float faverDuration;
    public int maxDimondsQueue = 3;
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
            EatCurrentColor(id);
        } else {
            if(color == Color.diamond) {
                EatDiamond(id);
            }
            else if (color == currentColor) {
                EatCurrentColor(id);
            }
            else if (color != Color.black) { // Its a different colot capsule
                GameEventsSystem.current.SceneReload();
            }
        }
    }

    private void ChangeColor(Color color) {
        currentColor = color;
    }

    private void EatDiamond(int id) {
        diamondQueue++;
        if(diamondQueue > maxDimondsQueue) {
            diamondQueue = 0;
            ActivateFaver();
        }

        dimonds++;
        GameEventsSystem.current.ScoreUpdate(dimonds, score);
        GameEventsSystem.current.SnakeEatTriggerEnter(id);
    }

    private void ActivateFaver() {
        isFaverOn = true;
        actualFaverDuration = faverDuration;
        GameEventsSystem.current.FaverStart();
    }

    private void DisableFaver() {
        isFaverOn = false;
        GameEventsSystem.current.FaverEnd();

        dimonds = 0;
        GameEventsSystem.current.ScoreUpdate(dimonds, score);
    }

    private void EatCurrentColor(int id) {
        diamondQueue = 0;
        score++;

        GameEventsSystem.current.ScoreUpdate(dimonds, score);
        GameEventsSystem.current.SnakeGain();
        GameEventsSystem.current.SnakeEatTriggerEnter(id);
    }

    private void Restart() {
        GameEventsSystem.current.SceneReload();
    }
}
