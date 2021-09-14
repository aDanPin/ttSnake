using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameEventsSystem : MonoBehaviour
{
    public static GameEventsSystem current;

    private void Awake() {
        current = this;
    }

    public event Action<Color> onColorChangeTriggerEnter;
    public void ColorChangeTriggerEnter(Color color) {
        if(onColorChangeTriggerEnter != null) {
            onColorChangeTriggerEnter(color);
        }
    }

    public event Action<int, Color> onSnakeBite;
    public void SnakeBiteTriggerEnter(int id, Color color) {
        if(onSnakeBite != null) {
            onSnakeBite(id, color);
        }
    }

    public event Action onSnakeGain;
    public void SnakeGain() {
        if(onSnakeBite != null) {
            onSnakeGain();
        }
    }

    public event Action onSnakeErose;
    public void SnakeErose() {
        if(onSnakeBite != null) {
            onSnakeErose();
        }
    }

    public event Action onSceneReloadTrigger;
    public void SceneReload(){
        if(onSceneReloadTrigger != null) {
            onSceneReloadTrigger();
        }
    }

    public event Action<int, int> onScoreUpdate;
    public void ScoreUpdate(int dimonds, int score) {
        if(onScoreUpdate != null) {
            onScoreUpdate(dimonds, score);
        }
    }

    public event Action onFaverStart;
    public void FaverStart() {
        if(onFaverStart != null) {
            onFaverStart();
        }
    }

    public event Action onFaverEnd;
    public void FaverEnd() {
        if(onFaverEnd != null) {
            onFaverEnd();
        }
    }

}
