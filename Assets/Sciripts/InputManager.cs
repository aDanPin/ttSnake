using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private SnakeMovingManager _smm;

    private void Start() {
        _smm = GameObject.FindWithTag("Snake")
                    .GetComponent<SnakeMovingManager>();        
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
    }
}
