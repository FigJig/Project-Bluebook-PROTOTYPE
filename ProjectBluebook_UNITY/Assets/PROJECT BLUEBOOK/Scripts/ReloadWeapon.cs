using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MidiJack;

public class ReloadWeapon : MonoBehaviour {

    public Text reloadingText;
    public bool gunLoaded;

    Scrollbar reloadScrollBar;

	// Use this for initialization
	void Start () {
        reloadScrollBar = GetComponent<Scrollbar>();
        gunLoaded = false;
        reloadingText.gameObject.GetComponent<Text>();
        
    }
	
	// Update is called once per frame
	void Update () {
        var s = MidiMaster.GetKnob(1,1);
        var d = MidiMaster.GetKnob(33);

        reloadScrollBar.value = s;

        if (s == 1.0 & gunLoaded == false)
        {
            reloadingText.gameObject.GetComponent<Text>().text = "GUN EMPTY, OPEN CANNISTER";
        }

        else if (s == 0.0 & gunLoaded == false)
        {          
            reloadingText.gameObject.GetComponent<Text>().text = "INSERT BULLET";

            if (d == 1.0)
            {
                reloadingText.gameObject.GetComponent<Text>().text = "BULLET LOADED, CLOSE CANNISTER";
                gunLoaded = true;
            }
        }

        else if (s == 1.0 & gunLoaded == true)
        {
            reloadingText.gameObject.GetComponent<Text>().text = "READY TO FIRE";
        }
	}
}
