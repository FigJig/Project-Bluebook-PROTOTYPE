using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiJack;
using UnityStandardAssets.ImageEffects;

public class LevelControl : MonoBehaviour {

    public GameObject enemyMesh1;
    public GameObject enemyMesh2;
    public GameObject resetAlertImage;
    public GameObject staticAS;

    public Text crosshairText;

    public static bool stageOne;

    public static bool stageTwoPrep;
    public static bool distanceReset;
    public static bool rotationReset;
    public static bool magReset;
    public static bool gravReset;

    public static bool distanceReset_S3;
    public static bool rotationReset_S3;
    public static bool magReset_S3;
    public static bool gravReset_S3;

    public static bool stageTwo;
    public static bool stageThree;

    public static bool resetControls;

    bool playResetAlert = false;
    bool staticSlider;
    bool staticSliderLocked;
    bool stageThreeStatusAlert = false;
    bool startResetAlert = false;
    bool coolDownStatus = false;
    float coolDown = 5f;

    // Use this for initialization
    void Start () {
        stageOne = true;
        stageTwoPrep = false;
        stageTwo = false;
        stageThree = false;
        distanceReset = false;
        rotationReset = false;
        magReset = false;
        gravReset = false;
        staticSlider = true;
        staticSliderLocked = false;
}

// Update is called once per frame
void Update () {

        var staticScript = gameObject.GetComponent<NoiseAndScratches>();
    

        if (stageTwoPrep == true)
        {
            
            coolDown -= Time.deltaTime;

            if (coolDown <= 0f & coolDownStatus == false)
            {
                staticScript.enabled = true;
                coolDown = 0f;
                startResetAlert = true;            
            }

            if (startResetAlert == true)
            {
                resetAlertImage.SetActive(true);
                resetAlertImage.GetComponent<Animator>().Play("ResetAlert_anim");
                startResetAlert = false;
                coolDownStatus = true;
            }
        }

        if (distanceReset == true & rotationReset == true & magReset == true & gravReset == true & resetControls == false & stageThree == false)
        {
            FireProjectile.hasFired = false;
            FireProjectile.systemText = false;
            resetAlertImage.SetActive(false);
            stageTwo = true;
            enemyMesh2.SetActive(true);
            enemyMesh1.SetActive(false);
            crosshairText.gameObject.GetComponent<Text>().text = "Locate target";
            distanceReset = false;
            rotationReset = false;
            magReset = false;
            gravReset = false;
        }

        if (stageTwo == true)
        {
            stageOne = false;
            stageTwoPrep = false;
            

            if (staticSlider == true)
            {
                var s = MidiMaster.GetKnob(7, 1);
                staticScript.grainIntensityMin = s * 5f;
                staticScript.grainIntensityMax = s * 5f;
                //staticSlider = false;

                if (s == 0f)
                {
                    CrosshairBehaviour.targetLocked = false;
                    CrosshairBehaviour.targetDetected = false;
                    staticSlider = false;
                    staticSliderLocked = true;
                    staticAS.SetActive(false);
                }
            }   

            if (staticSliderLocked == true)
            {
                staticScript.grainIntensityMin = 0f;
                staticScript.grainIntensityMax = 0f;
            }
        }

        if (resetControls == true)
        {
            stageTwo = false;

            coolDown -= Time.deltaTime;

            if (coolDown <= 0f & coolDownStatus == false)
            {
                startResetAlert = true;
                coolDown = 0f;
            }

            if (startResetAlert == true)
            {
                resetAlertImage.SetActive(true);
                resetAlertImage.GetComponent<Animator>().Play("ResetAlert_anim");
                startResetAlert = false;
                coolDownStatus = true;
            }

            if (stageThreeStatusAlert == false)
            {
                coolDown = 5f;
                coolDownStatus = false;
                ForcesControl.mSoundPlayed = false;
                ForcesControl.gSoundPlayed = false;
                FactorsControl.dSoundPlayed = false;
                FactorsControl.eSoundPlayed = false;
                distanceReset = false;
                rotationReset = false;
                magReset = false;
                gravReset = false;
                playResetAlert = true;
              //  resetAlertImage.SetActive(true);
               // resetAlertImage.GetComponent<Animator>().Play("ResetAlert_anim");
                stageThreeStatusAlert = true;
                Debug.Log("ResetControls started");
            }

            if (distanceReset_S3 == true & rotationReset_S3 == true & magReset_S3 == true & gravReset_S3 == true)
            {
                FireProjectile.hasFired = false;
                FireProjectile.systemText = false;
                resetAlertImage.SetActive(false);
                stageThree = true;
                crosshairText.gameObject.GetComponent<Text>().text = "Locate target";
                distanceReset_S3 = false;
                rotationReset_S3 = false;
                magReset_S3 = false;
                gravReset_S3 = false;
                Debug.Log("ResetControls done");
                CrosshairBehaviour.targetLocked = false;
                CrosshairBehaviour.targetDetected = false;
            }
        }

        if (stageThree == true)
        {
            resetControls = false;
            //stageTwo = false;
           // Debug.Log("Stage three started");
         


        }

	}

}
