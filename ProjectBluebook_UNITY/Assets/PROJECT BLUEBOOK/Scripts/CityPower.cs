using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiJack;

public class CityPower : MonoBehaviour {

    public GameObject playerPowerBar;
    public GameObject spotLights;
    public GameObject enemy;
    public GameObject BGM;
    public GameObject crosshairs;
    public GameObject canvas;

    public GameObject alertText;

    public GameObject transferPower;
    public Light globalLight;

    bool addText;
    bool globalLightControl;

    public AudioClip cityDepower;
    public AudioClip[] depowering;
    public AudioSource miscAudioSource;

    bool depower_1;
    bool depower_2;
    bool depower_3;
    bool depower_4;

    AudioSource cityPowerAudioSource;
    Slider cityPowerSlider;

    // Use this for initialization
    void Start()
    {
        depower_1 = false;
        depower_2 = false;
        depower_3 = false;
        depower_4 = false;
        cityPowerAudioSource = gameObject.GetComponent<AudioSource>();
        miscAudioSource.gameObject.GetComponent<AudioSource>();
        cityPowerSlider = GetComponent<Slider>();
        globalLight.GetComponent<Light>();
        globalLightControl = true;
        addText = false;
        alertText.gameObject.GetComponent<Text>().text = "\nSYSTEM: Drain city power.";
        alertText.gameObject.GetComponent<AlertTextScript>().lineCount += 2;
    }
	// Update is called once per frame
	void Update () {

        var s = MidiMaster.GetKnob(16,1);
        var d = MidiMaster.GetKnob(32);
        var miscAS = miscAudioSource.gameObject.GetComponent<AudioSource>();

        cityPowerSlider.value = s;

        if (globalLightControl == true)
        {
            globalLight.GetComponent<Light>().intensity = s;

            if (globalLight.GetComponent<Light>().intensity <= 0.05f)
            {
                globalLight.GetComponent<Light>().intensity = 0.05f;
                globalLightControl = false;
            }
        }

        if (s > 0.78f && s < 0.82 & depower_1 == false)
        {
            cityPowerAudioSource.clip = depowering[0];
            cityPowerAudioSource.PlayOneShot(cityPowerAudioSource.clip);
            depower_1 = true;
        }

        if (s > 0.58f && s < 0.62 & depower_2 == false)
        {
            cityPowerAudioSource.clip = depowering[1];
            cityPowerAudioSource.PlayOneShot(cityPowerAudioSource.clip);
            depower_2 = true;
        }

        if (s > 0.38f && s < 0.42 & depower_3 == false)
        {
            cityPowerAudioSource.clip = depowering[2];
            cityPowerAudioSource.PlayOneShot(cityPowerAudioSource.clip);
            depower_3 = true;
        }

        if (s > 0.18f && s < 0.22 & depower_4 == false)
        {
            cityPowerAudioSource.clip = depowering[3];
            cityPowerAudioSource.PlayOneShot(cityPowerAudioSource.clip);
            depower_4 = true;
        }


        if (s == 0.0)
        {
            cityPowerSlider.maxValue = 0.0f;
            alertText.gameObject.GetComponent<Text>().text = "\nSYSTEM: Drain city power.\nSYSTEM: Confirm power drain.";
            //transferPower.gameObject.SetActive(true);          
        }

        if (s == 0.0 & d == 1.0)
        {
            miscAS.clip = cityDepower;
            miscAS.PlayOneShot(miscAS.clip);
            canvas.gameObject.GetComponent<AudioController>().enabled = true;
            playerPowerBar.gameObject.GetComponent<PowerBar>().enabled = true;
            globalLight.GetComponent<Light>().intensity = 0.2f;
            spotLights.SetActive(true);
            crosshairs.SetActive(true);
            BGM.SetActive(true);
            enemy.SetActive(true);
            gameObject.SetActive(false);
            
        }

	}
}
