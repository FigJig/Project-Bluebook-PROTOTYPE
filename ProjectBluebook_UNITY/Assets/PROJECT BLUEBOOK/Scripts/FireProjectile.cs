using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiJack;

public class FireProjectile : MonoBehaviour {

    public GameObject factorsControl;
    public GameObject forcesControl;

    public GameObject projectile;

    public AudioSource BGM;
    public AudioSource humAS;
    public GameObject fadeToBlack;

    public Text alertText;
    public Text crosshairText;

    public AudioClip readyToFire;
    public AudioClip firing;
    public AudioSource miscAudioSource;
    AudioSource canvasAudioSource;

    public static bool systemText;
    public static bool hasFired;

    public bool playerVictory;

    bool startStageTwoPrep = false;

	// Use this for initialization
	void Start () {
        hasFired = false;
        playerVictory = false;
        systemText = false;
        canvasAudioSource = gameObject.GetComponent<AudioSource>();
		projectile.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

        var s = MidiMaster.GetKnob(41);
        var factors = factorsControl.gameObject.GetComponent<FactorsControl>();
        var forces = forcesControl.gameObject.GetComponent<ForcesControl>();
        var miscAS = miscAudioSource.gameObject.GetComponent<AudioSource>();

        if (playerVictory == true)
        {
            StartCoroutine("endGameAnim");
        }

        if (factors.distanceLocked == true & factors.rotationLocked == true & forces.magLocked == true & forces.gravLocked == true & factors.distanceValuesLock == true & factors.rotationValuesLock == true & forces.magValuesLock == true & forces.gravValuesLock == true)
        {         
            if (s == 1f & hasFired == false)
            {
                miscAS.clip = firing;
                miscAS.PlayOneShot(miscAS.clip);
                
				// LASER PARTICLE
				// NOTE #1: Cannot just use animation file in this particular case.
				//          Will need to instead activate/deactivate game object in order to keep proper "life" of motion trail. 
				// NOTE #2: A different script is attached to the projectile game object that will disable itself.

				//projectile.gameObject.GetComponent<Animator>().Play("ProjectileBlast");
				projectile.gameObject.SetActive(true);
                CameraShake.Shake(1.0f, 2f);



                crosshairText.gameObject.GetComponent<Text>().text = "Firing";
                alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Target hit";
                hasFired = true;  
                LevelControl.stageOne = false;

                if (startStageTwoPrep == false)
                {
                    LevelControl.stageTwoPrep = true;
                    startStageTwoPrep = true;
                }

                if (LevelControl.stageTwo == true)
                {
                    LevelControl.resetControls = true;
                }

                if (LevelControl.stageThree == true)
                {
                    playerVictory = true;
                    Debug.Log("Player victory true");
                }
                //alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Firing laser";
            }
            if (systemText == false)
            {
                miscAS.clip = readyToFire;
                miscAS.PlayOneShot(miscAS.clip);
                crosshairText.gameObject.GetComponent<Text>().text = "Ready to fire";
                alertText.gameObject.GetComponent<Text>().text = "\nSYSTEM: Factors and forces calibrated; rifle unlocked \nSYSTEM: Permission to fire - GRANTED";
                systemText = true;
            }

         
         
        }
	}

    IEnumerator endGameAnim()
    {
        yield return new WaitForSeconds(8f);
        BGM.gameObject.GetComponent<AudioSource>().volume -= 0.3f * Time.deltaTime;
        humAS.gameObject.GetComponent<AudioSource>().volume -= 0.3f * Time.deltaTime;
        fadeToBlack.SetActive(true);
         Color fadeToBlack_c = fadeToBlack.gameObject.GetComponent<Image>().color;
         fadeToBlack_c.a += 0.3f * Time.deltaTime;
         fadeToBlack.gameObject.GetComponent<Image>().color = fadeToBlack_c;
        yield return new WaitForSeconds(5f);     
      Application.LoadLevel(1);   
    }

}

//if (factorsControl.gameObject.GetComponent<FactorsControl>().distanceLocked == true & factorsControl.gameObject.GetComponent<FactorsControl>().rotationLocked == true & forcesControl.gameObject.GetComponent<ForcesControl>().magLocked == true & forcesControl.gameObject.GetComponent<ForcesControl>().gravLocked == true)