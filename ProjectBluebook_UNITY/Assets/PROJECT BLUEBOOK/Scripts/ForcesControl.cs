using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiJack;

public class ForcesControl : MonoBehaviour {

    public Slider magSlider;
    public Slider gravSlider;

    public Text alertText;

    //Target values
    public Text mTargetValue;
    public Text gTargetValue;

    public bool magLocked;
    public bool gravLocked;

    public bool magValuesLock;
    public bool gravValuesLock;

    public Transform magDial;
    public Transform gravDial;

    public GameObject magOrgPos;
    public GameObject magElement;
    public GameObject magTarget;
    public GameObject magTargetS2;
    public GameObject magTargetS3;

    public GameObject gravOrgPos;
    public GameObject gravElement;
    public GameObject gravTarget;
    public GameObject gravTargetS2;
    public GameObject gravTargetS3;

    public AudioClip magCalibrated;
    public AudioClip gravCalibrated;
    public AudioClip errorAudio;
    AudioSource forcesAudioSource;

    public static bool unlockForcesStageTwo;
    public static bool unlockForcesStageThree;

    public static bool mSoundPlayed = false;
    public static bool gSoundPlayed = false;

    void Start() {
        forcesAudioSource = gameObject.GetComponent<AudioSource>();
    }

    // Use this for initialization
    void Awake () {
        magSlider.gameObject.GetComponent<Slider>();
        gravSlider.gameObject.GetComponent<Slider>();
        magLocked = false;
        gravLocked = false;
        magValuesLock = false;
        gravValuesLock = false;
    }
	
	// Update is called once per frame
	void Update () {
        var s = MidiMaster.GetKnob(4);
        var d = MidiMaster.GetKnob(5);
        var i = MidiMaster.GetKnob(20,1);
        var f = MidiMaster.GetKnob(21,1);


        magDial.transform.rotation = Quaternion.Euler(new Vector3(0, 180, i * 270));
        gravDial.transform.rotation = Quaternion.Euler(new Vector3(0, 180, f * 270));

        if (LevelControl.stageOne == true)
        {
            if (magValuesLock == false)
            {
                if (s >= 0f && s < 0.3f & i == 0f & magLocked == false)
                {
                    forcesAudioSource.clip = errorAudio;
                    forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                    Debug.Log("incorrect mag value locked");
                    magLocked = true;
                }

                if (s >= 0f && s < 0.3f & i >= 0.1f & magLocked == true)
                {
                    // factorsAudioSource.clip = errorAudio;
                    //factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    Debug.Log("mag value unlocked");
                    magLocked = false;
                }

                if (s >= 0.59f && s < 1f & i == 0f & magLocked == false)
                {
                    forcesAudioSource.clip = errorAudio;
                    forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                    Debug.Log("incorrect distance value locked");
                    magLocked = true;
                }

                if (s >= 0.59f && s < 1f & i >= 0.1f & magLocked == true)
                {
                    // factorsAudioSource.clip = errorAudio;
                    //factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    Debug.Log("distance value unlocked");
                    magLocked = false;
                }
            }

            if (gravValuesLock == false)
            {
                if (d >= 0f && d < 0.565f & f == 0f & gravLocked == false)
                {
                    forcesAudioSource.clip = errorAudio;
                    forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                    Debug.Log("incorrect grav value locked");
                    gravLocked = true;
                }

                if (d >= 0f && d < 0.565f & f >= 0.1f & gravLocked == true)
                {
                    // factorsAudioSource.clip = errorAudio;
                    // factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    Debug.Log("grav value unlocked");
                    gravLocked = false;
                }

                if (d >= 0.59f && d < 1f & f == 0f & gravLocked == false)
                {
                    forcesAudioSource.clip = errorAudio;
                    forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                    Debug.Log("incorrect grav value locked");
                    gravLocked = true;
                }

                if (d >= 0.59f && d < 1f & f >= 0.1f & gravLocked == true)
                {
                    // factorsAudioSource.clip = errorAudio;
                    // factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                    Debug.Log("grav value unlocked");
                    gravLocked = false;
                }
            }

            if (magLocked == false)
            {
                magSlider.gameObject.GetComponent<Slider>().value = s;
            }

            if (gravLocked == false)
            {
                gravSlider.gameObject.GetComponent<Slider>().value = d;
            }

            if (s > 0.30f && s < 0.33f & i == 0f & magLocked == false)
            {
                forcesAudioSource.clip = magCalibrated;
                forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Magnetism calibrated.";
                magElement.transform.position = magTarget.transform.position;
                Debug.Log("Correct magnetism value locked");
                magLocked = true;
                magValuesLock = true;
                magSlider.gameObject.GetComponent<Slider>().value = 0.31496f;
            }

            if (d > 0.565f && d < 0.59f & f == 0f & gravLocked == false)
            {
                forcesAudioSource.clip = gravCalibrated;
                forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Gravity calibrated.";
                gravElement.transform.position = gravTarget.transform.position;
                Debug.Log("Correct gravity value locked");
                gravLocked = true;
                gravValuesLock = true;
                gravSlider.gameObject.GetComponent<Slider>().value = 0.57480f;
            }
        }

        if (LevelControl.stageTwoPrep == true)
        {
            magLocked = false;
            gravLocked = false;
            magValuesLock = false;
            gravValuesLock = false;

            if (magLocked == false)
            {
                magSlider.gameObject.GetComponent<Slider>().value = s;
            }

            if (gravLocked == false)
            {
                gravSlider.gameObject.GetComponent<Slider>().value = d;
            }

            if (s == 0f & i == 1f & magLocked == false & mSoundPlayed == false)
            {
                forcesAudioSource.clip = magCalibrated;
                forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                LevelControl.magReset = true;
                magElement.transform.position = magOrgPos.transform.position;
                Debug.Log("Mag reset");
                mSoundPlayed = true;

            }

            if (d == 0f & f == 1f & gravLocked == false & gSoundPlayed == false)
            {
                forcesAudioSource.clip = gravCalibrated;
                forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                LevelControl.gravReset = true;
                gravElement.transform.position = gravOrgPos.transform.position;
                Debug.Log("Grav rest");
                gSoundPlayed = true;

            }
        }

        if (LevelControl.stageTwo == true)
        {

            if (unlockForcesStageTwo == true)
            {
                if (CrosshairBehaviour.stageTwoTargetLocked == true)
                {
                    mTargetValue.gameObject.GetComponent<Text>().text = "M: 50µT";
                    gTargetValue.gameObject.GetComponent<Text>().text = "G: 9.8m/s^2";
                }

                if (magValuesLock == false)
                {
                    if (s >= 0f && s < 0.705f & i == 0f & magLocked == false)
                    {
                        forcesAudioSource.clip = errorAudio;
                        forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                        Debug.Log("incorrect mag value locked");
                        magLocked = true;
                    }

                    if (s >= 0f && s < 0.705f & i >= 0.1f & magLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        //factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("mag value unlocked");
                        magLocked = false;
                    }

                    if (s >= 0.725f && s < 1f & i == 0f & magLocked == false)
                    {
                        forcesAudioSource.clip = errorAudio;
                        forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                        Debug.Log("incorrect mag value locked");
                        magLocked = true;
                    }

                    if (s >= 0.725f && s < 1f & i >= 0.1f & magLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        //factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("mag value unlocked");
                        magLocked = false;
                    }
                }

                if (gravValuesLock == false)
                {
                    if (d >= 0f && d < 0.565f & f == 0f & gravLocked == false)
                    {
                        forcesAudioSource.clip = errorAudio;
                        forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                        Debug.Log("incorrect grav value locked");
                        gravLocked = true;
                    }

                    if (d >= 0f && d < 0.565f & f >= 0.1f & gravLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        // factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("grav value unlocked");
                        gravLocked = false;
                    }

                    if (d >= 0.59f && d < 1f & f == 0f & gravLocked == false)
                    {
                        forcesAudioSource.clip = errorAudio;
                        forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                        Debug.Log("incorrect grav value locked");
                        gravLocked = true;
                    }

                    if (d >= 0.59f && d < 1f & f >= 0.1f & gravLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        // factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("grav value unlocked");
                        gravLocked = false;
                    }
                }

                if (magLocked == false)
                {
                    
                    magSlider.gameObject.GetComponent<Slider>().value = s;
                }

                if (gravLocked == false)
                {
                    
                    gravSlider.gameObject.GetComponent<Slider>().value = d;
                }

                if (s > 0.705f && s < 0.725f & i == 0f & magLocked == false)
                {
                    forcesAudioSource.clip = magCalibrated;
                    forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                    alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Magnetism calibrated.";
                    magElement.transform.position = magTargetS2.transform.position;
                    Debug.Log("Correct magnetism value locked");
                    magLocked = true;
                    magValuesLock = true;
                    magSlider.gameObject.GetComponent<Slider>().value = 0.7165354f;
                    LevelControl.magReset = false;
                }

                if (d > 0.565f && d < 0.59f & f == 0f & gravLocked == false)
                {
                    forcesAudioSource.clip = gravCalibrated;
                    forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                    alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Gravity calibrated.";
                    gravElement.transform.position = gravTargetS2.transform.position;
                    Debug.Log("Correct gravity value locked");
                    gravLocked = true;
                    gravValuesLock = true;
                    gravSlider.gameObject.GetComponent<Slider>().value = 0.57480f;
                    LevelControl.gravReset = false;
                }
            }
        }

        if (LevelControl.resetControls == true)
        {
            magLocked = false;
            gravLocked = false;
            magValuesLock = false;
            gravValuesLock = false;
            LevelControl.stageTwo = false;
            LevelControl.stageTwoPrep = false;
            //LevelControl.resetControls = true;


            if (magLocked == false)
            {
                magSlider.gameObject.GetComponent<Slider>().value = s;
            }

            if (gravLocked == false)
            {
                gravSlider.gameObject.GetComponent<Slider>().value = d;
            }

            if (s == 0f & i == 1f & magLocked == false & mSoundPlayed == false)
            {
                forcesAudioSource.clip = magCalibrated;
                forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                LevelControl.magReset_S3 = true;
                magElement.transform.position = magOrgPos.transform.position;
                Debug.Log("Mag reset 3");
                mSoundPlayed = true;

            }

            if (d == 0f & f == 1f & gravLocked == false & gSoundPlayed == false)
            {
                forcesAudioSource.clip = gravCalibrated;
                forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                LevelControl.gravReset_S3 = true;
                gravElement.transform.position = gravOrgPos.transform.position;
                Debug.Log("Grav rest 3");
                gSoundPlayed = true;

            }
        }

        if (LevelControl.stageThree == true)
        {

            if (unlockForcesStageThree == true)
            {
                if (CrosshairBehaviour.stageTwoTargetLocked == true)
                {
                    mTargetValue.gameObject.GetComponent<Text>().text = "M: 50µT";
                    gTargetValue.gameObject.GetComponent<Text>().text = "G: 9.8m/s^2";
                }

                if (magValuesLock == false)
                {
                    if (s >= 0f && s < 0.705f & i == 0f & magLocked == false)
                    {
                        forcesAudioSource.clip = errorAudio;
                        forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                        Debug.Log("incorrect mag value locked");
                        magLocked = true;
                    }

                    if (s >= 0f && s < 0.705f & i >= 0.1f & magLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        //factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("mag value unlocked");
                        magLocked = false;
                    }

                    if (s >= 0.725f && s < 1f & i == 0f & magLocked == false)
                    {
                        forcesAudioSource.clip = errorAudio;
                        forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                        Debug.Log("incorrect mag value locked");
                        magLocked = true;
                    }

                    if (s >= 0.725f && s < 1f & i >= 0.1f & magLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        //factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("mag value unlocked");
                        magLocked = false;
                    }
                }

                if (gravValuesLock == false)
                {
                    if (d >= 0f && d < 0.565f & f == 0f & gravLocked == false)
                    {
                        forcesAudioSource.clip = errorAudio;
                        forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                        Debug.Log("incorrect grav value locked");
                        gravLocked = true;
                    }

                    if (d >= 0f && d < 0.565f & f >= 0.1f & gravLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        // factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("grav value unlocked");
                        gravLocked = false;
                    }

                    if (d >= 0.59f && d < 1f & f == 0f & gravLocked == false)
                    {
                        forcesAudioSource.clip = errorAudio;
                        forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                        Debug.Log("incorrect grav value locked");
                        gravLocked = true;
                    }

                    if (d >= 0.59f && d < 1f & f >= 0.1f & gravLocked == true)
                    {
                        // factorsAudioSource.clip = errorAudio;
                        // factorsAudioSource.PlayOneShot(factorsAudioSource.clip);
                        Debug.Log("grav value unlocked");
                        gravLocked = false;
                    }
                }

                if (magLocked == false)
                {

                    magSlider.gameObject.GetComponent<Slider>().value = s;
                }

                if (gravLocked == false)
                {

                    gravSlider.gameObject.GetComponent<Slider>().value = d;
                }

                if (s > 0.705f && s < 0.725f & i == 0f & magLocked == false)
                {
                    forcesAudioSource.clip = magCalibrated;
                    forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                    alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Magnetism calibrated.";
                    magElement.transform.parent = magTargetS3.transform;
                    magElement.transform.position = magTargetS3.transform.position;
                    Debug.Log("Correct magnetism value locked");
                    magLocked = true;
                    magValuesLock = true;
                    magSlider.gameObject.GetComponent<Slider>().value = 0.7165354f;
                }

                if (d > 0.565f && d < 0.59f & f == 0f & gravLocked == false)
                {
                    forcesAudioSource.clip = gravCalibrated;
                    forcesAudioSource.PlayOneShot(forcesAudioSource.clip);
                    alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Gravity calibrated.";
                    gravElement.transform.parent = gravTargetS3.transform;
                    gravElement.transform.position = gravTargetS3.transform.position;
                    Debug.Log("Correct gravity value locked");
                    gravLocked = true;
                    gravValuesLock = true;
                    gravSlider.gameObject.GetComponent<Slider>().value = 0.57480f;
                }
            }
        }

    }
}
