using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AccuracyScript : MonoBehaviour
{

    public GameObject factors;
    public GameObject forces;

    public float accPercent;

    bool dLocked;
    bool eLocked;
    bool mLocked;
    bool gLocked;

    bool secondStageStarted = false;
    bool thirdStageStarted = false;

    Text accText;

    // Use this for initialization
    void Start()
    {
        dLocked = false;
        eLocked = false;
        mLocked = false;
        gLocked = false;
        accPercent = 0;
        accText = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        accText.text = accPercent + "%";

        if (factors.gameObject.GetComponent<FactorsControl>().distanceLocked == true & dLocked == false)
        {
            accPercent += 25;
            dLocked = true;
        }

        if (factors.gameObject.GetComponent<FactorsControl>().rotationLocked == true & eLocked == false)
        {
            accPercent += 25;
            eLocked = true;
        }

        if (forces.gameObject.GetComponent<ForcesControl>().magLocked == true & mLocked == false)
        {
            accPercent += 25;
            mLocked = true;
        }

        if (forces.gameObject.GetComponent<ForcesControl>().gravLocked == true & gLocked == false)
        {
            accPercent += 25;
            gLocked = true;
        }

        if (LevelControl.stageTwo == true)
        {
            if (secondStageStarted == false)
            {
                accPercent = 0;
                secondStageStarted = true;
                dLocked = false;
                eLocked = false;
                mLocked = false;
                gLocked = false;
            }
        }

        if (LevelControl.stageThree == true)
        {
            if (thirdStageStarted == false)
            {
                accPercent = 0;
                thirdStageStarted = true;
                dLocked = false;
                eLocked = false;
                mLocked = false;
                gLocked = false;
            }
        }
    }
}
