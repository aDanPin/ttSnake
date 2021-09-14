using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    public static int globalId = 0;
    public int localId;
    
    enum Color{
        red, blue, yellow,
        green, perple, 
    }
    
    private void Start() {
        localId = globalId;
        ++globalId;
    }



}
