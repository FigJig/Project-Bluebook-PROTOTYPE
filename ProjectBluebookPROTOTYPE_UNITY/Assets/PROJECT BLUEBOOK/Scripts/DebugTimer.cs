using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugTimer : MonoBehaviour {

	public float currentTime;
	public float minutes;
	public float seconds;
	public Text gameTimeText;
	public GameObject enemyMesh;
	public bool debugActive;

	// Use this for initialization
	void Awake () {
		debugActive = false;
		//gameTimeText.GetComponent<Text>().enabled = false;
		gameTimeText.gameObject.SetActive(false);
	}

	// Update is called once per frame
	void Update () {



		// Seconds-to-Minutes Conversion
		minutes = Mathf.FloorToInt(currentTime / 60);
		seconds = currentTime % 60;
		if(seconds > 59) seconds = 59;


		if (enemyMesh.activeSelf == true) {
			debugActive = true;
		}


		if (debugActive) {

			gameTimeText.gameObject.SetActive(true);
			
//			int minutes, seconds, miliseconds, fraction;
//
//			minutes = Mathf.FloorToInt(Time.time / 60);
//			seconds = Mathf.FloorToInt(Time.time % 60);
			//miliseconds = Mathf.FloorToInt (Time.time % 1000);
			//fraction = miliseconds % 1000;


			gameTimeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
			currentTime += Time.deltaTime;

			gameTimeText.text = "TOTAL TIME: " + minutes.ToString () + ":" + string.Format("{00:00}", seconds);
			//gameTime.text = string.Format("{0:0}:{01}:{0:2}", minutes, seconds, (int)miliseconds);
			//gameTime.text = string.Format ("{0:00}:{1:00}:{2:000}", minutes, seconds,fraction);
		}
	}
}
