using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// USING STATEMENTS
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameController : MonoBehaviour {

    [Header("Hazard Options")]
    public GameObject[] hazard; // What are we spawning?
    public Vector2 spawnValue; // Where do we spawn our hazards?
    public int hazardCount; // How many hazards per wave?
    public float startWait; // How long until the first wave?
    public float spawnWait; // How long between each hazard in each wave?
    public float waveWait; // How long between each wave of enemies?

    [Header("Text Options")]
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    [Header("Game Audio Source")]
    public AudioClip victorySFX;

    private bool gameOver;
    private bool restart;
    private int score;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        score = 0;

        scoreText.text = "";
        restartText.text = "";
        gameOverText.text = "";

        UpdateScore();

        StartCoroutine(SpawnWaves());

        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                // THE OLD WAY (DON'T USE THIS ONE)
                // Application.LoadLevel(Application.loadedLevel);
                // THE NEW WAY
                SceneManager.LoadScene("SpaceShooter"); // Works fine but is prone to error
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Better but more complicated
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

	}

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while(true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector2 spawnPosition = new Vector2(spawnValue.x, Random.Range(-spawnValue.y, spawnValue.y));
                //                                      12                          -3.5           3.5
                Quaternion spawnRotation = Quaternion.identity; // Default rotation
                Instantiate(hazard[0], spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait); //Wait before spawning each hazard
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.gameObject.SetActive(true);
                restartText.text = "Press R for Restart";
                restart = true;
                break;
            }
        }
    }

    // Update the score text
    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        // score = score + newScoreValue;
        // Debug.Log("Score is " + score);

        if (score % 200 == 0)
        {
            audioSource.clip = victorySFX;
            audioSource.Play();
        }

        UpdateScore();
    }

    public void GameOver()
    {
        // Debug.Log("Game is Over");
        gameOverText.gameObject.SetActive(true);
        gameOverText.text = "Game Over";
        gameOver = true;
    }
}
