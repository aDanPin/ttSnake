using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public string color;
    private void OnTriggerEnter(Collider other) {
        GameEventsSystem.current.ColorChangeTriggerEnter(color);
    }
}
