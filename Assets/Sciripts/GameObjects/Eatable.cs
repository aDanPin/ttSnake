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

        GameEventsSystem.current.onSnakeEate += Eating;
    }

    private void OnTriggerEnter(Collider other) {
        GameEventsSystem.current.SnakeBiteTriggerEnter(localId, color);
    }

    public void Eating(int id) {
        if(id == localId) {
            Destroy(gameObject);
        }
    }

    private void OnDestroy() {
        GameEventsSystem.current.onSnakeEate -= Eating;
    }
}
