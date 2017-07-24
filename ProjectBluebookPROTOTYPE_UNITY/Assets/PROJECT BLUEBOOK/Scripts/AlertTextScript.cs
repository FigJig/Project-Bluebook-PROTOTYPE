using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlertTextScript : MonoBehaviour {

    public int lineCount;
    Text alertText;

	// Use this for initialization
	void Start () {
        lineCount = 0;
        alertText = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if (lineCount == 7)
        {
            alertText.text = "";
            lineCount = 0;
        }	
	}
}
