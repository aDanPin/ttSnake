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

    private void Update() {
        if(_mr.material == null)
            Debug.Log("null 2");
        if ( _mr == null)
            Debug.Log("null 1");
    }

    private void ChangeColor(Color color) {
        switch(color) {
            case Color.yellow:
                ChangeColorToYellow();
                break;
            case Color.blue:
                ChangeColorToBlue();
                break;
            case Color.green:
                ChangeColorToGreen();
                break;
            case Color.purple:
                ChangeColorToPurple();
                break;
            case Color.red:
                ChangeColorToRed();
                break;
            case Color.orange:
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
