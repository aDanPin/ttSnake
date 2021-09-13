using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovingManager : MonoBehaviour
{
    public Vector3 mainMovingDirection;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        MoveUpToMainDirection();        
    }

    private void MoveUpToMainDirection() {
        transform.position += mainMovingDirection.normalized
                                * speed * Time.deltaTime;
    }
}
