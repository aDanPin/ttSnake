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

}
