using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MidiJack;

public class Test : MonoBehaviour {

    //public int knobNumber;
    public bool knobPressed;

	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.color = Color.white;
        knobPressed = false;
	}
	
	// Update is called once per frame
	void Update () {

        var s = MidiMaster.GetKnob(32);

        var d = MidiMaster.GetKnob(48);

        if (s == 1.0)
            {
            GetComponent<Renderer>().material.color = Color.red;
            }

        if (d == 1.0)
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }
}
