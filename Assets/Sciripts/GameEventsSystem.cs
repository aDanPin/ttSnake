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

    public event Action<String> onColorChangeTriggerEnter;
    public void ColorChangeTriggerEnter(string color) {
        if(onColorChangeTriggerEnter != null) {
            onColorChangeTriggerEnter(color);
        }
    }

}
