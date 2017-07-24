using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiJack;

public class PowerBar : MonoBehaviour {

    public GameObject crosshairs;
    public Image crosshairUI;
    public Image enemyTargetUI;
    public GameObject alertText;
    public GameObject crosshairText;
    public Text percentText;

    public GameObject powerPercent;
    public GameObject accuracyPercent;
    public GameObject topUIL;
    public GameObject topUIR;
    public GameObject crosshairControls;
    public GameObject aimUITriangle;
    public GameObject mechHumAS;

    public GameObject[] aimDirections;

    public Image factorsHeader;
    public Text dLabel;
    public GameObject dValues;
    public Image dDial;
    public Image dOnOff;
    public Image dFill;
    public Image dHandle;
    public Image dBackground;
    public Text eLabel;
    public GameObject eValues;
    public Image eDial;
    public Image eOnOff;
    public Image eFill;
    public Image eHandle;
    public Image eBackground;

    public Image forcesHeader;
    public Text mLabel;
    public GameObject mValues;
    public Image mDial;
    public Image mOnOff;
    public Image mFill;
    public Image mHandle;
    public Image mBackground;
    public Text gLabel;
    public GameObject gValues;
    public Image gDial;
    public Image gOnOff;
    public Image gFill;
    public Image gHandle;
    public Image gBackground;

    public Image gunModeIndicator;
    public Image gunModeNight;
    public Image gunModeNormal;

    public AudioClip systemsOnline;

    AudioSource systemsAudio;
    Slider playerSlider;

    bool sliderActive;
    bool playerHPActive = false;

    public float playerPower;

	// Use this for initialization
	void Start () {
        crosshairs.SetActive(true);
        powerPercent.SetActive(true);
        accuracyPercent.SetActive(true);
        topUIL.SetActive(true);
        topUIR.SetActive(true);
        sliderActive = true;
        playerSlider = GetComponent<Slider>();
        alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Power suit";
        alertText.gameObject.GetComponent<AlertTextScript>().lineCount += 1;
        percentText.gameObject.GetComponent<Text>();
        systemsAudio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {

        var s = MidiMaster.GetKnob(0);

        if (playerPower <= 0f)
        {
            playerPower = 0f;
        }

        if(playerHPActive == true)
        {
            percentText.gameObject.GetComponent<Text>().text = playerPower + "%";
        }

        if (sliderActive == true)
        {
            playerSlider.value = s;

            playerPower = s * 100;

            percentText.gameObject.GetComponent<Text>().text = playerPower + "%";

            Color aimTriangle_c = aimUITriangle.gameObject.GetComponent<Image>().color;
            aimTriangle_c.a = s;
            aimUITriangle.gameObject.GetComponent<Image>().color = aimTriangle_c;

            Color c = crosshairUI.gameObject.GetComponent<Image>().color;
            c.a = s;
            crosshairUI.gameObject.GetComponent<Image>().color = c;

            Color d = enemyTargetUI.gameObject.GetComponent<Image>().color;
            d.a = s;
            enemyTargetUI.gameObject.GetComponent<Image>().color = d;

            Color fHeader = factorsHeader.gameObject.GetComponent<Image>().color;
            fHeader.a = s;
            factorsHeader.gameObject.GetComponent<Image>().color = fHeader;

            Color foHeader = forcesHeader.gameObject.GetComponent<Image>().color;
            foHeader.a = s;
            forcesHeader.gameObject.GetComponent<Image>().color = foHeader;

            //Distance UI

            Color dLabel_c = dLabel.gameObject.GetComponent<Text>().color;
            dLabel_c.a = s;
            dLabel.gameObject.GetComponent<Text>().color = dLabel_c;

            Color dDial_c = dDial.gameObject.GetComponent<Image>().color;
            dDial_c.a = s;
            dDial.gameObject.GetComponent<Image>().color = dLabel_c;

            Color dOnOff_c = dOnOff.gameObject.GetComponent<Image>().color;
            dOnOff_c.a = s;
            dOnOff.gameObject.GetComponent<Image>().color = dOnOff_c;

            Color dFill_c = dFill.gameObject.GetComponent<Image>().color;
            dFill_c.a = s;
            dFill.gameObject.GetComponent<Image>().color = dFill_c;

            Color dHandle_c = dHandle.gameObject.GetComponent<Image>().color;
            dHandle_c.a = s;
            dHandle.gameObject.GetComponent<Image>().color = dHandle_c;

            Color dBackground_c = dBackground.gameObject.GetComponent<Image>().color;
            dBackground_c.a = s;
            dBackground.gameObject.GetComponent<Image>().color = dBackground_c;

            //Earth Rotation UI

            Color eLabel_c = eLabel.gameObject.GetComponent<Text>().color;
            eLabel_c.a = s;
            eLabel.gameObject.GetComponent<Text>().color = eLabel_c;

            Color eDial_c = eDial.gameObject.GetComponent<Image>().color;
            eDial_c.a = s;
            eDial.gameObject.GetComponent<Image>().color = eLabel_c;

            Color eOnOff_c = eOnOff.gameObject.GetComponent<Image>().color;
            eOnOff_c.a = s;
            eOnOff.gameObject.GetComponent<Image>().color = eOnOff_c;

            Color eFill_c = eFill.gameObject.GetComponent<Image>().color;
            eFill_c.a = s;
            eFill.gameObject.GetComponent<Image>().color = eFill_c;

            Color eHandle_c = eHandle.gameObject.GetComponent<Image>().color;
            eHandle_c.a = s;
            eHandle.gameObject.GetComponent<Image>().color = eHandle_c;

            Color eBackground_c = eBackground.gameObject.GetComponent<Image>().color;
            eBackground_c.a = s;
            eBackground.gameObject.GetComponent<Image>().color = eBackground_c;

            //GeoMag UI

            Color mLabel_c = mLabel.gameObject.GetComponent<Text>().color;
            mLabel_c.a = s;
            mLabel.gameObject.GetComponent<Text>().color = mLabel_c;

            Color mDial_c = mDial.gameObject.GetComponent<Image>().color;
            mDial_c.a = s;
            mDial.gameObject.GetComponent<Image>().color = mLabel_c;

            Color mOnOff_c = mOnOff.gameObject.GetComponent<Image>().color;
            mOnOff_c.a = s;
            mOnOff.gameObject.GetComponent<Image>().color = mOnOff_c;

            Color mFill_c = mFill.gameObject.GetComponent<Image>().color;
            mFill_c.a = s;
            mFill.gameObject.GetComponent<Image>().color = mFill_c;

            Color mHandle_c = mHandle.gameObject.GetComponent<Image>().color;
            mHandle_c.a = s;
            mHandle.gameObject.GetComponent<Image>().color = mHandle_c;

            Color mBackground_c = mBackground.gameObject.GetComponent<Image>().color;
            mBackground_c.a = s;
            mBackground.gameObject.GetComponent<Image>().color = mBackground_c;

            //GeoGrav UI

            Color gLabel_c = gLabel.gameObject.GetComponent<Text>().color;
            gLabel_c.a = s;
            gLabel.gameObject.GetComponent<Text>().color = gLabel_c;

            Color gDial_c = gDial.gameObject.GetComponent<Image>().color;
            gDial_c.a = s;
            gDial.gameObject.GetComponent<Image>().color = gLabel_c;

            Color gOnOff_c = gOnOff.gameObject.GetComponent<Image>().color;
            gOnOff_c.a = s;
            gOnOff.gameObject.GetComponent<Image>().color = gOnOff_c;

            Color gFill_c = gFill.gameObject.GetComponent<Image>().color;
            gFill_c.a = s;
            gFill.gameObject.GetComponent<Image>().color = gFill_c;

            Color gHandle_c = gHandle.gameObject.GetComponent<Image>().color;
            gHandle_c.a = s;
            gHandle.gameObject.GetComponent<Image>().color = gHandle_c;

            Color gBackground_c = gBackground.gameObject.GetComponent<Image>().color;
            gBackground_c.a = s;
            gBackground.gameObject.GetComponent<Image>().color = gBackground_c;

            //Gun Modes UI

            Color gModeIndi_c = gunModeIndicator.gameObject.GetComponent<Image>().color;
            gModeIndi_c.a = s;
            gunModeIndicator.gameObject.GetComponent<Image>().color = gModeIndi_c;

            Color gModeNight_c = gunModeNight.gameObject.GetComponent<Image>().color;
            gModeNight_c.a = s;
            gunModeNight.gameObject.GetComponent<Image>().color = gModeNight_c;

            Color gModeNormal_c = gunModeNormal.gameObject.GetComponent<Image>().color;
            gModeNormal_c.a = s;
            gunModeNormal.gameObject.GetComponent<Image>().color = gModeNormal_c;

        }

        if (s == 1.0 & sliderActive == true)
        {
            StartCoroutine("dValuesOn");
            StartCoroutine("eValuesOn");
            StartCoroutine("mValuesOn");
            StartCoroutine("gValuesOn");
            mechHumAS.SetActive(true);
            playerHPActive = true;
            systemsAudio.clip = systemsOnline;
            systemsAudio.PlayOneShot(systemsAudio.clip);
            crosshairControls.gameObject.GetComponent<CrosshairBehaviour>().enabled = true;
            alertText.gameObject.GetComponent<AlertTextScript>().lineCount += 1;
            alertText.gameObject.GetComponent<Text>().text += "\nSYSTEM: Locate target";
            //ammoAudioSource.clip = ammoAudio[0];
            //ammoAudioSource.PlayOneShot(ammoAudioSource.clip);
        }

        if (s == 1.0)
        {
            crosshairText.SetActive(true);
            //alertText.gameObject.GetComponent<AlertTextScript>().enabled = true;           
            sliderActive = false;
            //crosshairUI.SetActive(true);
            //playerSlider.minValue = 1.0f;
            //c.a = 1.0f;
        }

	}

    IEnumerator dValuesOn()
    {
        dValues.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        dValues.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        dValues.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        dValues.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        dValues.SetActive(true);
        StopCoroutine("dValuesOn");
    }

    IEnumerator eValuesOn()
    {
        eValues.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        eValues.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        eValues.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        eValues.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        eValues.SetActive(true);
        StopCoroutine("eValuesOn");
    }

    IEnumerator mValuesOn()
    {
        mValues.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        mValues.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        mValues.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        mValues.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        mValues.SetActive(true);
        StopCoroutine("mValuesOn");
    }

    IEnumerator gValuesOn()
    {
        gValues.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        gValues.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        gValues.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        gValues.SetActive(false);
        yield return new WaitForSeconds(0.7f);
        gValues.SetActive(true);
        StopCoroutine("gValuesOn");
    }

}
