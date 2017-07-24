using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerProjectile : MonoBehaviour {

	public GameObject projectile;
	public GameObject explosion1;
	public GameObject explosion2;
    public GameObject explosion3;
	public bool nextExplode;
    public bool nextExplode3;
	public Transform mainUI;

	// UI Shake Variables
	public float shakeDuration;
	public float shakeStrength;
	public int shakeVibrato;
	public float shakeRandomness;
	public bool shakeSnapping;
	public bool shakeFadeOut;


	void Awake(){
		projectile.gameObject.SetActive (false);
		explosion1.gameObject.SetActive (false);
		explosion1.gameObject.SetActive (false);
		nextExplode = false;
        nextExplode3 = false;
	}



	// Apply both Camera and UI shake as an animation event.
	public void projectileShake(){
		// duration: 1f
		// strengthL 45f
		// vibrato: 100
		// randomness: 70f
		// snapping: true
		// fadeOut: true
		mainUI.DOShakePosition(shakeDuration,shakeStrength,shakeVibrato,shakeRandomness,shakeSnapping,shakeFadeOut);
	}


	// Disable projectile game object
	// > REQUIRED FOR PROPER MOTION TRAIL.
	public void disableProjectile(){
		projectile.gameObject.SetActive (false);
		nextExplode = true;
	}


	public void activateExplosion1(){
		if (!nextExplode) {
			explosion1.gameObject.SetActive (true);

		}
	}


	public void activateExplosion2(){
		if (nextExplode & nextExplode3 == false) {
			explosion2.gameObject.SetActive (true);
            nextExplode3 = true;
		}
	}
    public void activateExplosion3()
    {
        if (nextExplode3 == true)
        {
            explosion3.gameObject.SetActive(true);
        }
    }
}
