using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

    public float speed;
    public Boundary boundary;
    public GameObject laser;
    public Transform laserSpawn;
    public float nextLaser;

    // Private variables
    private Rigidbody2D rBody;
    private float myTime = 0.0f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        // Fire laser
        myTime = myTime + Time.deltaTime;
        if (Input.GetButton("Fire1") && myTime > nextLaser)
        {
            Instantiate(laser, laserSpawn.position, laserSpawn.rotation);

            myTime = 0.0f;
        }
    }

    // Used when performing physics calculation
    private void FixedUpdate()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal"); // Returns a value between -1 and 1 whenever left, right, a or d is pushed
        float moveVertical = Input.GetAxis("Vertical"); // Returns a value between -1 and 1 whenever up, down, w or s is pushed

            // Debug.Log("H=" + moveHorizontal + " V=" + moveVertical);

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rBody = this.gameObject.GetComponent<Rigidbody2D>(); // Establishes a connection to the Rigidbody2D component
        rBody.velocity = movement * speed;
        rBody.position = new Vector2(Mathf.Clamp(rBody.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rBody.position.y, boundary.yMin, boundary.yMax));
    }
}
