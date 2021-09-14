using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovingManager : MonoBehaviour
{
    public Vector3 mainMovingDirection;
    public float speed;
    public float faverSpeedScale;
    public float lateralSpeed; 
    public float maxLateralDelta;


    private Vector3 _leftDirection;
    private Vector3 _rightDirection;


    private void Start() {
        _leftDirection = Quaternion.Euler(0, -90, 0) * mainMovingDirection;
        _rightDirection = Quaternion.Euler(0, 90, 0) * mainMovingDirection;

        GameEventsSystem.current.onFaverStart += OnFaverStart;
        GameEventsSystem.current.onFaverEnd += OnFaverEnd;
    }

    void Update()
    {
        MoveUpToMainDirection();        
    }

    private void MoveUpToMainDirection() {
        transform.position += mainMovingDirection.normalized
                                * speed * Time.deltaTime;
    }

    public void MoveByDelta(float delta) {
        if(delta < 0)
            MoveLeft(Mathf.Abs(delta));
        else
            MoveRight(Mathf.Abs(delta));
    }

    public void MoveLeft(float delta) {
        Vector3 nextPosition = transform.position + _leftDirection * delta
                                                    * lateralSpeed;
        if(maxLateralDelta - Mathf.Abs(nextPosition.z) > 0 ) {
            transform.position = nextPosition;
        } else {
            nextPosition = transform.position;
            nextPosition.z = -maxLateralDelta;

            transform.position = nextPosition;            
        }
    }
    public void MoveRight(float delta) {
        Vector3 nextPosition = transform.position + _rightDirection * delta
                                                    * lateralSpeed;
        if(maxLateralDelta - Mathf.Abs(nextPosition.z) > 0 ) {
            transform.position = nextPosition;
        } else {
            nextPosition = transform.position;
            nextPosition.z = maxLateralDelta;

            transform.position = nextPosition;
        }
    }

    private void OnFaverStart() {
        Vector3 nextPosition = transform.position;
        nextPosition.z = 0;

        transform.position = nextPosition;

        speed *= faverSpeedScale;
    }

    private void OnFaverEnd() {
        speed /= faverSpeedScale;
    }
}
