using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiJack;

public class AudioController : MonoBehaviour {

    public GameObject playerPowerBar;
    public AudioClip[] beeps;
    public AudioClip staticAudio;
    public AudioClip secondStageBGM;
    public AudioSource staticAS;
	public AudioSource systemPrompt;
	public AudioClip System;
    public AudioSource BGM;

    public GameObject warningSystem;

    AudioSource canvasAudioSource;

    bool staticAudioPlaying = false;
    bool secondStageBGMPlaying = false;

	// Use this for initialization
	void Start () {
        canvasAudioSource = gameObject.GetComponent<AudioSource>();
        InvokeRepeating("SoundBeeps", 3f, 3f);
    }
	
	// Update is called once per frame
	void Update () {

        if (LevelControl.stageTwoPrep == true & staticAudioPlaying == false & warningSystem.activeSelf == true)
        {
            staticAS.gameObject.GetComponent<AudioSource>().clip = staticAudio;
            staticAS.gameObject.GetComponent<AudioSource>().Play();
            staticAudioPlaying = true;
        }

        if (LevelControl.stageTwo == true & secondStageBGMPlaying == false)
        {
            BGM.gameObject.GetComponent<AudioSource>().clip = secondStageBGM;
            BGM.gameObject.GetComponent<AudioSource>().Play();
            secondStageBGMPlaying = true;
			systemPrompt.GetComponent<AudioSource>().clip = System;
			systemPrompt.GetComponent<AudioSource>().Play();
        }

	}

    void SoundBeeps () {
        int beepsIndex = Random.Range(0, beeps.Length);

        canvasAudioSource.clip = beeps[beepsIndex];
        canvasAudioSource.PlayOneShot(canvasAudioSource.clip);
    }
}
