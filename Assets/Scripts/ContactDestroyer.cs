using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDestroyer : MonoBehaviour {

    public GameObject explosionSkull;
    public GameObject explosionPlayer;
    public int score;

    private GameController gameControllerScript;

    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");

        if (gameControllerObject != null)
        {
            gameControllerScript = gameControllerObject.GetComponent<GameController>();
        }
        else
            Debug.Log("Cannot find Game Controller script on Object");


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Boundary" || other.tag == "Hazard")
        {
            return;
            // Debug.Log("DestroyByContact");
        }

        if (other.tag == "Player")
        {
            Vector3 deltaP = (this.transform.position + other.transform.position) / 2; // Delta of Player and this
            
            // Create our explosion animation
            Instantiate(explosionPlayer, deltaP, other.transform.rotation);
            // Instantiate(explosionPlayer, other.transform.position, other.transform.rotation);

            // GAME OVER
            gameControllerScript.GameOver();
        }
        else
        {
            Instantiate(explosionSkull, this.transform.position, this.transform.rotation);
            gameControllerScript.AddScore(score);
        }

        

        Destroy(other.gameObject); // Destroy other thing
        Destroy(this.gameObject); // Destroy this thing
	}
}
