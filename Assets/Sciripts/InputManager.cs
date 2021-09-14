using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private SnakeMovingManager _smm;
    private SnakeTail _st;
    private float _WIDTH;


    private bool isFaver = false;

    private void Start() {
        _smm = GameObject.FindWithTag("Snake")
                    .GetComponent<SnakeMovingManager>();
        _st = GameObject.FindWithTag("Snake")
                    .GetComponent<SnakeTail>();

        _WIDTH  = Screen.width;

        GameEventsSystem.current.onFaverStart += OnFaverStart;
        GameEventsSystem.current.onFaverEnd += OnFaverEnd;
    }

    private void OnFaverStart() {
        isFaver = true;
    }

    private void OnFaverEnd() {
        isFaver = false;
    }

    void Update()
    {
        if(!isFaver) {
        foreach(Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 deltaVector = touch.deltaPosition;
                _smm.MoveByDelta(deltaVector.x / _WIDTH);
            }
        }
        }
    }
}
