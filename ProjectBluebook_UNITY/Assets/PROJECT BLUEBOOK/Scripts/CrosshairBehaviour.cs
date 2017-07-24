using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiJack;

public class CrosshairBehaviour : MonoBehaviour {

    public GameObject alertText;
    public Transform enemyTargetPos;

    public Text crosshairText;

    public GameObject aimUp;
    public GameObject aimDown;
    public GameObject aimLeft;
    public GameObject aimRight;

    public GameObject targetStageOne;
    public GameObject targetStageTwo;
    public GameObject targetStageThree;

    public GameObject targetValues;
    public GameObject forces;
    public GameObject factors;

    public GameObject crosshairTargets;

    public static bool targetDetected;
    public static bool targetLocked;

    public AudioClip targetAcquired;
    AudioSource crosshairAudioSource;

    bool borderHit;

    public static bool stageTwoTargetLocked = false;
    public static bool stageThreeTargetLocked = false;

	// Use this for initialization
	void Start () {
        targetLocked = false;
        targetDetected = false;
        crosshairAudioSource = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        var s = MidiMaster.GetKnob(1, 0.5f);
        var d = MidiMaster.GetKnob(17, 0.5f);
        var i = MidiMaster.GetKnob(33);

        if (targetLocked == false)
        {

            if (s >= 0.65f)
            {
              
               aimUp.SetActive(true);
                transform.position += Vector3.up * 60f * Time.deltaTime;
            }
            else
            {
                
                aimUp.SetActive(false);
            }


            if (s <= 0.45f)
            {
               
                aimDown.SetActive(true);
                transform.position += Vector3.down * 60f * Time.deltaTime;
            }
            else
            {
              
                 aimDown.SetActive(false);
            }


            if (d >= 0.7f)
            {
               
                aimRight.SetActive(true);
                transform.position += Vector3.right * 60f * Time.deltaTime;
            }
            else
            {
             
                aimRight.SetActive(false);
            }


            if (d <= 0.3f)
            {
               
                aimLeft.SetActive(true);
                transform.position += Vector3.left * 60f * Time.deltaTime;
            }
            else
            {
            
                aimLeft.SetActive(false);
            }
          
        }

        if (targetLocked == true) 
        {
            return;
        }

        if (LevelControl.stageOne == true)
        {

            if (targetDetected == true)
            {
                if (i == 1.0f)
                {
                    StartCoroutine("targetValuesOn");

                    //Color aimUp_c = aimUp.gameObject.GetComponent<Image>().color;
                    //aimUp_c.a = 0f;
                    //aimUp.gameObject.GetComponent<Image>().color = aimUp_c;

                    aimDown.SetActive(false);
                    aimUp.SetActive(false);
                    aimLeft.SetActive(false);
                    aimRight.SetActive(false);
                    crosshairAudioSource.clip = targetAcquired;
                    crosshairAudioSource.PlayOneShot(crosshairAudioSource.clip);
                    targetLocked = true;
                    crosshairTargets.SetActive(true);
                    transform.position = enemyTargetPos.transform.position;
                    factors.gameObject.GetComponent<FactorsControl>().enabled = true;
                    forces.gameObject.GetComponent<ForcesControl>().enabled = true;
                    alertText.gameObject.GetComponent<AlertTextScript>().lineCount += 1;
                    alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Target acquired.";
                    crosshairText.gameObject.GetComponent<Text>().text = "Calibrate Firing Conditions";                  
                }
            }
        }

        if (LevelControl.stageTwo == true)
        {
            targetStageOne.SetActive(false);
            targetStageTwo.SetActive(true);
            //targetLocked = false;

            if (targetDetected == true & targetLocked == false)
            {

                if (i == 1.0f)
                {
                    FactorsControl.unlockFactorsStageTwo = true;
                    ForcesControl.unlockForcesStageTwo = true;
                    stageTwoTargetLocked = true;
                    StartCoroutine("targetValuesOn");

                    aimDown.SetActive(false);
                    aimUp.SetActive(false);
                    aimLeft.SetActive(false);
                    aimRight.SetActive(false);
                    targetLocked = true;
                    crosshairAudioSource.clip = targetAcquired;
                    crosshairAudioSource.PlayOneShot(crosshairAudioSource.clip);
                    transform.position = targetStageTwo.transform.position;
                    alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Target acquired.";
                    crosshairText.gameObject.GetComponent<Text>().text = "Calibrate Firing Conditions";
                }
            }
        }

        if (LevelControl.resetControls)
        {
            LevelControl.stageTwo = false;
            targetDetected = false;
            crosshairAudioSource.volume = 0f;
            targetLocked = false;
        }

        if (LevelControl.stageThree == true)
        {
            targetStageOne.SetActive(false);
            targetStageTwo.SetActive(false);
            targetStageThree.SetActive(true);
            //targetLocked = false;
            LevelControl.stageTwo = false;

            if (targetDetected == true & targetLocked == false)
            {

                if (i == 1.0f)
                {
                    FactorsControl.unlockFactorsStageThree = true;
                    ForcesControl.unlockForcesStageThree = true;
                    stageThreeTargetLocked = true;
                    StartCoroutine("targetValuesOn");

                    aimDown.SetActive(false);
                    aimUp.SetActive(false);
                    aimLeft.SetActive(false);
                    aimRight.SetActive(false);
                    targetLocked = true;
                    crosshairAudioSource.volume = 1f;
                    crosshairAudioSource.clip = targetAcquired;
                    crosshairAudioSource.PlayOneShot(crosshairAudioSource.clip);
                    transform.parent = targetStageThree.transform;
                    transform.position = targetStageThree.transform.position;
                    alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Target acquired.";
                    crosshairText.gameObject.GetComponent<Text>().text = "Calibrate Firing Conditions";
                }
            }
        }
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "EnemyTarget")
        {
            //alertText.gameObject.GetComponent<AlertTextScript>().lineCount += 1;
            targetDetected = true;
            crosshairText.gameObject.GetComponent<Text>().text = "Target detected - lock in";
            //alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Target detected - lock in";
        }     

        if (other.gameObject.tag == "CrosshairBorder")
        {
            borderHit = true;
        }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject.tag == "EnemyTarget")
        {
            //alertText.gameObject.GetComponent<AlertTextScript>().lineCount += 1;
            targetDetected = false;
            crosshairText.gameObject.GetComponent<Text>().text = "Locate target";
        }
    }

    IEnumerator TempDisable()
    {
        targetLocked = true;
        yield return new WaitForSeconds(0.5f);
        targetLocked = false;
        borderHit = false;
        StopCoroutine("TempDisable");
    }

    IEnumerator targetValuesOn()
    {
        targetValues.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        targetValues.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        targetValues.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        targetValues.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        targetValues.SetActive(true);
        StopCoroutine("targetValuesOn");
    }
}
