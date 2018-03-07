using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryDestroyer : MonoBehaviour {
    /*
    // Runs when an object first enters into a collider zone
    // Runs once!
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    // Runs while an object is inside a collider
    // Runs every frame
    private void OnTriggerStay2D(Collider2D collision)
    {

    }

    // Runs when an object first exits a collider zone
    // Runs once
    // OnCollision for when objects bounce off each other
    */
    private void OnTriggerExit2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }

    // OnCollision for when objects bounce off each other
}
