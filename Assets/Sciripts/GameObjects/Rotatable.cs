using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatable : MonoBehaviour
{
    public Vector3 rotateAmount; 

    void Update()
    {
        transform.Rotate(rotateAmount * Time.deltaTime);
    }
}
