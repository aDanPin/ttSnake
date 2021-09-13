using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeColorManager : MonoBehaviour
{
    public Material yellow, purple, blue,
                    orange, green, red;
    private MeshRenderer _mr;
    void Start()
    {
        GameEventsSystem.current.onColorChangeTriggerEnter += ChangeColor;

        _mr = GetComponent<MeshRenderer>();
    }

    private void ChangeColor(string color) {
        switch(color) {
            case "Yellow":
                ChangeColorToYellow();
                break;
            case "Blue":
                ChangeColorToBlue();
                break;
            case "Green":
                ChangeColorToGreen();
                break;
            case "Purple":
                ChangeColorToPurple();
                break;
            case "Red":
                ChangeColorToRed();
                break;
            case "Orange":
                ChangeColorToOrange();
                break;
            default: break;
        }
    }

    private void ChangeColorToYellow() {
        _mr.material = yellow;
    }

    private void ChangeColorToPurple() {
        _mr.material = purple;
    }
    private void ChangeColorToBlue() {
        _mr.material = blue;
    }
    private void ChangeColorToGreen() {
        _mr.material = green;
    }
    private void ChangeColorToOrange() {
        _mr.material = orange;
    }
    private void ChangeColorToRed() {
        _mr.material = red;
    }
}
