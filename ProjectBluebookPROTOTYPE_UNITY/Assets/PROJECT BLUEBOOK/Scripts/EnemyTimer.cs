using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyTimer : MonoBehaviour {

	// NOTE - TIME CONVERSION
	// Actual time value calculated in seconds, even when displayed in minutes.

	// TIME REFERENCE:
	// [FLOAT VALUE]   ||  [ACTUAL TIME]
	// 60  --> 1:00min
	// 90  --> 1:30min
	// 120 --> 2:00min
	// 150 --> 2:30min
	// 180 --> 3:00min

	// Enemy Game Object
	// > Required for activating the initial countdown.
	// > Enemy Mesh #2 game object must be inactive by default.
	public GameObject enemyMesh1; // Enemy's 1st form
	public GameObject enemyMesh2; // Enemy's 2nd form

	// Countdown Timer Variables
	public float timeLeft;
	public float timeMax;
	public float timeExtend;
	public bool secondChance;
	public bool stop = true;
	public float minutes;
	public float seconds;
	public Text timeText;


	// Cooldown Variables
	// > NOTE: Cooldown will use standard seconds. No need for minutes.
	public bool attackOn;
	public float cooldownLeft;
	public float cooldownMax;
	public Text cooldownText;


	// Laser Animation Variables
	public Animator laserAnim;

	// Enemy "Armor"
	// > Enemy mesh with special particle-shader.
	// > For visual dramatic effect when enemy prepares to shoot laser.
	public GameObject enemyArmor;

	// Timer Border
	public GameObject timeBorder;


	// Audio Source
	public AudioSource enemyAudio;

//	// Game Over Counter
//	// > Point-system that determines Game Over condition.
//	public int gameLives = 2;


	//======================================================================


	void Awake () {
		timeLeft = timeMax;
		cooldownLeft = cooldownMax;
		attackOn = false;
		timeText.GetComponent<Text>().enabled = false; // Initially hide countdown text.
		cooldownText.GetComponent<Text>().enabled = false;
		enemyArmor.SetActive (false);
		timeBorder.SetActive (false);
		secondChance = false;
		//laserAnim = GetComponent<Animator> ();
	}

//	public void startTimer(float from){
//		stop = false;
//		timeLeft = from;
//		Update();
//		//StartCoroutine(updateCoroutine());
//	}

	void Update() {

		// ENEMY 2nd FORM ACTIVATION
		// > Activate initial countdown when coresponding enemy mesh game object is active.
		if (enemyMesh2.activeSelf == true) {
			stop = false;
			timeText.GetComponent<Text>().enabled = true;
			timeBorder.SetActive (true);
		}

		// Seconds-to-Minutes Conversion
		minutes = Mathf.FloorToInt(timeLeft / 60);
		seconds = timeLeft % 60;
		if(seconds > 59) seconds = 59;

		// COUNTDOWN FINISH
		if(minutes < 0) {
			stop = true;
			attackOn = true;
			minutes = 0;
			seconds = 0;
		}
			

		// ATTACK LOCK (ENEMY ATTACK ACTIVATION)
		// > Enemy Attack Behaviour goes here.
		if (attackOn) {
			laserAnim.Play ("Laser_attack");
			cooldownLeft -= Time.deltaTime;
			cooldownText.GetComponent<Text>().enabled = true;
			cooldownText.text = "COOL-DOWN: " + Mathf.FloorToInt(cooldownLeft) + "s";
			secondChance = true;
			//enemyArmor.SetActive (true);
			//enemyArmor.activeSelf = true;
		}


		// COUNTDOWN RESET
		if (cooldownLeft < 0) {
			laserAnim.Play ("Laser_inactive");
			stop = false;
			timeLeft = timeMax;
		}



		// Second-chance Time Extension
		// > Grant the player extra time after being hit by x1 enemy laser.
		if (secondChance) {
			timeMax = timeExtend;
		}


		// COUNTDOWN REDUCTION
		if(!stop){
			laserAnim.Play ("Laser_inactive");
			timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
			timeLeft -= Time.deltaTime;
			cooldownLeft = cooldownMax;
			cooldownText.GetComponent<Text>().enabled = false;
			attackOn = false;
			enemyArmor.SetActive (false);
		}
	}


//	IEnumerator playEnemyCharge(float waitTime){
//		yield return new WaitForSeconds (waitTime);
//			enemyAudio.PlayOneShot (sfxLaserCharge, audioVolume);
//			playSound = false;
//			Debug.Log ("SOUND IS PLAYING");
//	}


	private void enemyShake(){
		CameraShake.Shake (0.1f, 0.2f);
	}

	public void secondChanceActive(){
		secondChance = true;
	}


//	public void playEnemyCharge(){
//		enemyAudio.PlayOneShot (sfxLaserCharge, audioVolume);
//		playSound = false;
//		Debug.Log ("SOUND IS PLAYING");
//	}


//	private IEnumerator updateCoroutine(){
//		while(!stop){
//			text.text = string.Format("{0:0}:{1:00}", minutes, seconds);
//			Debug.Log ("AAAAAAA");
//			yield return new WaitForSeconds(0.2f); // Ensure timer does not desync upon activation.
//		}
//	}



	//=====
}