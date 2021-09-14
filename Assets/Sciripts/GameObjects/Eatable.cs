using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eatable : MonoBehaviour
{
    public static int globalId = 0;
    public int localId;
    public Color color;
    
    private void Start() {
        localId = globalId;
        ++globalId;

        GameEventsSystem.current.onSnakeBite += Eating;
    }

    private void OnTriggerEnter(Collider other) {
        GameEventsSystem.current.SnakeBiteTriggerEnter(localId, color);
    }

    public void Eating(int id, Color color) {
        if(id == localId) {
            Destroy(gameObject);
        }
    }
}
