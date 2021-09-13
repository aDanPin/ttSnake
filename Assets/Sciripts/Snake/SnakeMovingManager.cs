using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovingManager : MonoBehaviour
{
    public Vector3 mainMovingDirection;
    private Vector3 _leftDirection;
    private Vector3 _rightDirection;
    public float speed;
    public float lateralSpeed; 
    public float maxLateralDelta;

    private void Start() {
        _leftDirection = Quaternion.Euler(0, -90, 0) * mainMovingDirection;
        _rightDirection = Quaternion.Euler(0, 90, 0) * mainMovingDirection;
    }

    void Update()
    {
        MoveUpToMainDirection();        
    }

    private void MoveUpToMainDirection() {
        transform.position += mainMovingDirection.normalized
                                * speed * Time.deltaTime;
    }

    public void MoveLeft() {
        Vector3 nextPosition = transform.position + _leftDirection * lateralSpeed * Time.deltaTime;
        if(maxLateralDelta - Mathf.Abs(nextPosition.z) > 0 ) {
            transform.position = nextPosition;
        }
    }
    public void MoveRight() {
        Vector3 nextPosition = transform.position + _rightDirection * lateralSpeed * Time.deltaTime;
        if(maxLateralDelta - Mathf.Abs(nextPosition.z) > 0 ) {
            transform.position = nextPosition;
        }
    }
}
