using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private SnakeMovingManager _smm;
    private SnakeTail _st;

    private bool isFaver = false;

    private void Start() {
        _smm = GameObject.FindWithTag("Snake")
                    .GetComponent<SnakeMovingManager>();
        _st = GameObject.FindWithTag("Snake")
                    .GetComponent<SnakeTail>();

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
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                _smm.MoveLeft();
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                _smm.MoveRight();
            }
            if(Input.GetKeyDown(KeyCode.A)){
                _st.AddNode();
            }
            if(Input.GetKeyDown(KeyCode.Q)){
                _st.RemoveNode();
            }
        }
    }
}
