using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScoreManager : MonoBehaviour
{
    public Text text;

    private void Start() {
        GameEventsSystem.current.onScoreUpdate += ChangeScore;
    }

    private void ChangeScore(int dimonds, int score) {
        text.text = "Dimonds: " + dimonds + "  |  "
                    + "Score: " + score;
    }
}
