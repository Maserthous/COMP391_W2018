using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    // Used when performing physics calculation
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); // Returns a value between -1 and 1 whenever left, right, a or d is pushed
        float moveVertical = Input.GetAxis("Vertical"); // Returns a value between -1 and 1 whenever up, down, w or s is pushed

        // Debug.Log("H=" + moveHorizontal + " V=" + moveVertical);

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        Rigidbody2D rBody = this.gameObject.GetComponent<Rigidbody2D>(); // Establishes a connection to the Rigidbody2D component
        rBody.velocity = movement * speed;
    }
}
