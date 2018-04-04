using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class PauseController : MonoBehaviour {

    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;

    private Text text;

	void Start () {
        text = GetComponent<Text>();
	}
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
	}

    private void Pause()
    {
        text.enabled = !text.enabled;
        Time.timeScale = Time.timeScale == 0 ? 1 : 0; // Turnary statement
        PlayAudio();
        /*
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;
        */
    }

    private void PlayAudio()
    {
        if (Time.timeScale == 0)
        {
            paused.TransitionTo(0.01f);
        }
        else
        {
            unpaused.TransitionTo(0.01f);
        }
    }
}
