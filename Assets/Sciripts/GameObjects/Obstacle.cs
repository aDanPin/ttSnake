using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float cooldown = 0.1f;
    private float actualColldown = 0f;

    private void Update() {
        if(actualColldown > 0)
            actualColldown -= Time.deltaTime;
    }
    private void OnCollisionStay(Collision other) {
        if(other.gameObject.tag == "Snake") {
            if(actualColldown <= 0) {
                GameEventsSystem.current.SnakeErose();
                actualColldown = cooldown;
            }
        }
    }
}
