﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeBite : MonoBehaviour
{
    public Color currentColor;
    private int diamondQueue;
    private int score;

    void Start()
    {
        GameEventsSystem.current.onSnakeBite += Bite;
        GameEventsSystem.current.onColorChangeTriggerEnter += ChangeColor;
    }

    private void Bite(int id, Color color) {
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

    private void ChangeColor(Color color) {
        currentColor = color;
    }

    private void EatDiamond() {
        diamondQueue++;
        if(diamondQueue == 3) {
            diamondQueue = 0;
            ActivateFaver();
        }
    }

    private void ActivateFaver() {

    }

    private void EatCurrentColor() {
        diamondQueue = 0;
        score ++;
    }

    private void Restart() {
        SceneManager.LoadScene("SampleScene");        
    }
}