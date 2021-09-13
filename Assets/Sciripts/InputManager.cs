using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private SnakeMovingManager _smm;
    private SnakeTail _st;

    private void Start() {
        _smm = GameObject.FindWithTag("Snake")
                    .GetComponent<SnakeMovingManager>();
        _st = GameObject.FindWithTag("Snake")
                    .GetComponent<SnakeTail>();
    }

    void Update()
    {
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
