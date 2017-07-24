using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiJack;

public class FactorsControl : MonoBehaviour {

    public Slider distanceSlider;
    public Slider rotationSlider;

    public Text alertText;

    //Target values
    public Text dTargetValue;
    public Text eTargetValue;

    public bool distanceLocked;
    public bool rotationLocked;
    public bool distanceLock;
    public bool rotationLock;

    public bool distanceValuesLock;
    public bool rotationValuesLock;

    public Transform distanceDial;
    public Transform earthDial;

    public GameObject distanceOrgPos;
    public GameObject distanceElement;
    public GameObject distanceTarget;
    public GameObject distanceTargetS2;
    public GameObject distanceTargetS3;

    public GameObject rotationOrgPos;
    public GameObject rotationElement;
    public GameObject rotationTarget;
    public GameObject rotationTargetS2;
    public GameObject rotationTargetS3;

    public AudioClip distanceCalibrated;
    public AudioClip rotationCalibrated;
    public AudioClip errorAudio;
    AudioSource factorsAudioSource;

    public static bool unlockFactorsStageTwo = false;
    public static bool unlockFactorsStageThree = false;

    public static bool dSoundPlayed = false;
    public static bool eSoundPlayed = false;

	// Use this for initialization

    void Start () {
        alertText.gameObject.GetComponent<AlertTextScript>().lineCount = 0;
        alertText.gameObject.GetComponent<Text>().text = "\nSYSTEM: Calibrate Factors and Forces.";
        factorsAudioSource = gameObject.GetComponent<AudioSource>();
    }

	void Awake () {
        distanceSlider.gameObject.GetComponent<Slider>();
        rotationSlider.gameObject.GetComponent<Slider>();
        distanceLocked = false;
        rotationLocked = false;
        distanceLock = false;
        rotationLock = false;

        distanceValuesLock = false;
        rotationValuesLock = false;
    }
	
	// Update is called once per frame
	void Update () {
        var s = MidiMaster.GetKnob(2);
        var d = MidiMaster.GetKnob(3);
        var i = MidiMaster.GetKnob(18,1);
        var f = MidiMaster.GetKnob(19,1);

        distanceDial.transform.rotation = Quaternion.Euler(new Vector3(0, 180, i * 270));
        earthDial.transform.rotation = Quaternion.Euler(new Vector3(0, 180, f * 270));

        if (LevelControl.stageOne == true)
        {
            if (distanceValuesLock == false)
            {
                if (s >= 0f && s < 0.565f & i == 0f & distanceLocked == false)
                {
                    factorsAudioSource.clip = errorAudio;
                    factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    Debug.Log("incorrect distance value locked");
                    distanceLocked = true;
                }

                if (s >= 0f && s < 0.565f & i >= 0.1f & distanceLocked == true)
                {
                   // factorsAudioSource.clip = errorAudio;
                    //factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    Debug.Log("distance value unlocked");
                    distanceLocked = false;
                }

                if (s >= 0.6f && s < 1f & i == 0f & distanceLocked == false)
                {
                    factorsAudioSource.clip = errorAudio;
                    factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    Debug.Log("incorrect distance value locked");
                    distanceLocked = true;
                }

                if (s >= 0.6f && s < 1f & i >= 0.1f & distanceLocked == true)
                {
                    // factorsAudioSource.clip = errorAudio;
                    //factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    Debug.Log("distance value unlocked");
                    distanceLocked = false;
                }
            }

            if (rotationValuesLock == false)
            {
                if (d >= 0f && d < 0.43f & f == 0f & rotationLocked == false)
                {
                    factorsAudioSource.clip = errorAudio;
                    factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    Debug.Log("incorrect rotation value locked");
                    rotationLocked = true;
                }

                if (d >= 0f && d < 0.43f & f >= 0.1f & rotationLocked == true)
                {
                   // factorsAudioSource.clip = errorAudio;
                   // factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    Debug.Log("rotation value unlocked");
                    rotationLocked = false;
                }

                if (d >= 0.455f && d < 1f & f == 0f & rotationLocked == false)
                {
                    factorsAudioSource.clip = errorAudio;
                    factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    Debug.Log("incorrect rotation value locked");
                    rotationLocked = true;
                }

                if (d >= 0.455f && d < 1f & f >= 0.1f & rotationLocked == true)
                {
                    // factorsAudioSource.clip = errorAudio;
                    // factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    Debug.Log("rotation value unlocked");
                    rotationLocked = false;
                }
            }

            if (distanceLocked == false)
            {
                distanceSlider.gameObject.GetComponent<Slider>().value = s;
            }

            if (rotationLocked == false)
            {
                rotationSlider.gameObject.GetComponent<Slider>().value = d;
            }

            if (s > 0.565f && s < 0.60f & i == 0f & distanceLocked == false)
            {
                factorsAudioSource.clip = distanceCalibrated;
                factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Distance calibrated.";
                distanceElement.transform.position = distanceTarget.transform.position;
                Debug.Log("Correct distance value locked");
                distanceLocked = true;
                distanceValuesLock = true;
                distanceSlider.gameObject.GetComponent<Slider>().value = 0.57480f;
            }

            if (d > 0.43f && d < 0.455f & f == 0f & rotationLocked == false)
            {
                factorsAudioSource.clip = rotationCalibrated;
                factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Rotation calibrated.";
                rotationElement.transform.position = rotationTarget.transform.position;
                Debug.Log("Correct rotation value locked");
                rotationLocked = true;
                rotationValuesLock = true;
                rotationSlider.gameObject.GetComponent<Slider>().value = 0.44094f;
            }
        }

        if (LevelControl.stageTwoPrep == true)
        {
            distanceLocked = false;
            rotationLocked = false;

            distanceValuesLock = false;
            rotationValuesLock = false;

            alertText.gameObject.GetComponent<Text>().text = "\nSYSTEM: Calibrate Factors and Forces.";
            // dTargetValue.gameObject.GetComponent<Text>().text = "D: XXX";
            // eTargetValue.gameObject.GetComponent<Text>().text = "E: XXX";

            if (distanceLocked == false)
            {
                distanceSlider.gameObject.GetComponent<Slider>().value = s;
            }

            if (rotationLocked == false)
            {
                rotationSlider.gameObject.GetComponent<Slider>().value = d;
            }

            if (s == 0f & i == 1f & distanceLocked == false & dSoundPlayed == false)
            {
                factorsAudioSource.clip = distanceCalibrated;
                factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                LevelControl.distanceReset = true;
                distanceElement.transform.position = distanceOrgPos.transform.position;
                Debug.Log("Distance reset");
                dSoundPlayed = true;
     
            }

            if (d == 0f & f == 1f & rotationLocked == false & eSoundPlayed == false)
            {
                factorsAudioSource.clip = rotationCalibrated;
                factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                LevelControl.rotationReset = true;
                rotationElement.transform.position = rotationOrgPos.transform.position;
                Debug.Log("Rotation rest");
                eSoundPlayed = true;
            }
        }

        if (LevelControl.stageTwo == true)
        {
            
            if (unlockFactorsStageTwo == true)
            {

                if (CrosshairBehaviour.stageTwoTargetLocked == true)
                {
                    dTargetValue.gameObject.GetComponent<Text>().text = "D: 200M";
                    eTargetValue.gameObject.GetComponent<Text>().text = "E: 1.0°";
                }

                if (distanceValuesLock == false)
                {
                    if (s >= 0f && s < 0.305f & i == 0f & distanceLocked == false)
                    {
                        factorsAudioSource.clip = errorAudio;
                        factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("incorrect distance value locked");
                        distanceLocked = true;
                    }

                    if (s >= 0f && s < 0.305f & i >= 0.1f & distanceLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        //factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("distance value unlocked");
                        distanceLocked = false;
                    }

                    if (s >= 0.325f && s < 1f & i == 0f & distanceLocked == false)
                    {
                        factorsAudioSource.clip = errorAudio;
                        factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("incorrect distance value locked");
                        distanceLocked = true;
                    }

                    if (s >= 0.325f && s < 1f & i >= 0.1f & distanceLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        //factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("distance value unlocked");
                        distanceLocked = false;
                    }
                }

                if (rotationValuesLock == false)
                {
                    if (d >= 0f && d < 0.705f & f == 0f & rotationLocked == false)
                    {
                        factorsAudioSource.clip = errorAudio;
                        factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("incorrect rotation value locked");
                        rotationLocked = true;
                    }

                    if (d >= 0f && d < 0.705f & f >= 0.1f & rotationLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        // factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("rotation value unlocked");
                        rotationLocked = false;
                    }

                    if (d >= 0.725f && d < 1f & f == 0f & rotationLocked == false)
                    {
                        factorsAudioSource.clip = errorAudio;
                        factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("incorrect rotation value locked");
                        rotationLocked = true;
                    }

                    if (d >= 0.725f && d < 1f & f >= 0.1f & rotationLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        // factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("rotation value unlocked");
                        rotationLocked = false;
                    }
                }

                if (distanceLocked == false)
                {
                    
                    distanceSlider.gameObject.GetComponent<Slider>().value = s;
                }

                if (rotationLocked == false)
                {
                    
                    rotationSlider.gameObject.GetComponent<Slider>().value = d;
                }


                if (s > 0.305f && s < 0.325f & i == 0f & distanceLocked == false)
                {
                    factorsAudioSource.clip = distanceCalibrated;
                    factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Distance calibrated.";
                    distanceElement.transform.position = distanceTargetS2.transform.position;
                    Debug.Log("Correct distance value locked");
                    distanceLocked = true;
                    distanceValuesLock = true;
                    distanceSlider.gameObject.GetComponent<Slider>().value = 0.3149606f;
                }

                if (d > 0.705f && d < 0.725f & f == 0f & rotationLocked == false)
                {
                    factorsAudioSource.clip = rotationCalibrated;
                    factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Rotation calibrated.";
                    rotationElement.transform.position = rotationTargetS2.transform.position;
                    Debug.Log("Correct rotation value locked");
                    rotationLocked = true;
                    rotationValuesLock = true;
                    rotationSlider.gameObject.GetComponent<Slider>().value = 0.7165354f;
                }
            }
        }

        if (LevelControl.resetControls == true)
        {
            distanceLocked = false;
            rotationLocked = false;

            distanceValuesLock = false;
            rotationValuesLock = false;

            alertText.gameObject.GetComponent<Text>().text = "\nSYSTEM: Calibrate Factors and Forces.";
            // dTargetValue.gameObject.GetComponent<Text>().text = "D: XXX";
            // eTargetValue.gameObject.GetComponent<Text>().text = "E: XXX";

            if (distanceLocked == false)
            {
                distanceSlider.gameObject.GetComponent<Slider>().value = s;
            }

            if (rotationLocked == false)
            {
                rotationSlider.gameObject.GetComponent<Slider>().value = d;
            }

            if (s == 0f & i == 1f & distanceLocked == false & dSoundPlayed == false)
            {
                factorsAudioSource.clip = distanceCalibrated;
                factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                LevelControl.distanceReset_S3 = true;
                distanceElement.transform.position = distanceOrgPos.transform.position;
                Debug.Log("Distance reset 3");
                dSoundPlayed = true;
               // LevelControl.distanceReset = false;

            }

            if (d == 0f & f == 1f & rotationLocked == false & eSoundPlayed == false)
            {
                factorsAudioSource.clip = rotationCalibrated;
                factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                LevelControl.rotationReset_S3 = true;
                rotationElement.transform.position = rotationOrgPos.transform.position;
                Debug.Log("Rotation rest 3");
                eSoundPlayed = true;
               // LevelControl.rotationReset = false;
            }
        }

        if (LevelControl.stageThree == true)
        {
            if (unlockFactorsStageThree == true)
            {
                if (CrosshairBehaviour.stageThreeTargetLocked == true)
                {
                    dTargetValue.gameObject.GetComponent<Text>().text = "D: 200M";
                    eTargetValue.gameObject.GetComponent<Text>().text = "E: 1.0°";
                }

                if (distanceValuesLock == false)
                {
                    if (s >= 0f && s < 0.305f & i == 0f & distanceLocked == false)
                    {
                        factorsAudioSource.clip = errorAudio;
                        factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("incorrect distance value locked");
                        distanceLocked = true;
                    }

                    if (s >= 0f && s < 0.305f & i >= 0.1f & distanceLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        //factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("distance value unlocked");
                        distanceLocked = false;
                    }

                    if (s >= 0.325f && s < 1f & i == 0f & distanceLocked == false)
                    {
                        factorsAudioSource.clip = errorAudio;
                        factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("incorrect distance value locked");
                        distanceLocked = true;
                    }

                    if (s >= 0.325f && s < 1f & i >= 0.1f & distanceLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        //factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("distance value unlocked");
                        distanceLocked = false;
                    }
                }

                if (rotationValuesLock == false)
                {
                    if (d >= 0f && d < 0.705f & f == 0f & rotationLocked == false)
                    {
                        factorsAudioSource.clip = errorAudio;
                        factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("incorrect rotation value locked");
                        rotationLocked = true;
                    }

                    if (d >= 0f && d < 0.705f & f >= 0.1f & rotationLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        // factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("rotation value unlocked");
                        rotationLocked = false;
                    }

                    if (d >= 0.725f && d < 1f & f == 0f & rotationLocked == false)
                    {
                        factorsAudioSource.clip = errorAudio;
                        factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("incorrect rotation value locked");
                        rotationLocked = true;
                    }

                    if (d >= 0.725f && d < 1f & f >= 0.1f & rotationLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        // factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("rotation value unlocked");
                        rotationLocked = false;
                    }
                }

                if (distanceLocked == false)
                {

                    distanceSlider.gameObject.GetComponent<Slider>().value = s;
                }

                if (rotationLocked == false)
                {

                    rotationSlider.gameObject.GetComponent<Slider>().value = d;
                }


                if (s > 0.305f && s < 0.325f & i == 0f & distanceLocked == false)
                {
                    factorsAudioSource.clip = distanceCalibrated;
                    factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Distance calibrated.";
                    distanceElement.transform.parent = distanceTargetS3.transform;
                    distanceElement.transform.position = distanceTargetS3.transform.position;
                    Debug.Log("Correct distance value locked");
                    distanceLocked = true;
                    distanceValuesLock = true;
                    distanceSlider.gameObject.GetComponent<Slider>().value = 0.3149606f;
                }

                if (d > 0.705f && d < 0.725f & f == 0f & rotationLocked == false)
                {
                    factorsAudioSource.clip = rotationCalibrated;
                    factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Rotation calibrated.";
                    rotationElement.transform.parent = rotationTargetS3.transform;
                    rotationElement.transform.position = rotationTargetS3.transform.position;
                    Debug.Log("Correct rotation value locked");
                    rotationLocked = true;
                    rotationValuesLock = true;
                    rotationSlider.gameObject.GetComponent<Slider>().value = 0.7165354f;
                }
            }
        }

    }
}
