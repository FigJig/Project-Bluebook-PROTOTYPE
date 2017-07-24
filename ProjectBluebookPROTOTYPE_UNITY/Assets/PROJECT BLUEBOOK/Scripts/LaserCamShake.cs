using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LaserCamShake : MonoBehaviour {

    public Animator laserAnimator;
    public float shakeDuration;
    public float shakeAmount;
    public GameObject enemyArmor;
    public Transform mainUI; // The Parent Object holding all other UI objects.
    public AudioSource laserAudioSource;
    public AudioSource laserHitAudioSource;
    public AudioClip sfxLaserBlast;
    public AudioClip sfxLaserHit;
    public GameObject percentText;


    // NOTE: Call the below functions as an Animation Event
    //       in the Laser Cylinder object's animation timeline.


    // Skip to the Laser-Attack animation by code via an animation event.
    public void playLaserAttack() {
        laserAnimator.Play("Laser_attack");
    }

    // Apply CamShake as an Animation Event.
    public void laserScreenShake() {
        CameraShake.Shake(shakeDuration, shakeAmount);
    }

    // Activate Enemy Armor Game Object.
    public void enemyArmorEnable() {
        enemyArmor.SetActive(true);
    }

    // Deactivate Enemy Armor Game Object.
    // > Can also place laser audio clip to this function.
    public void enemyArmorDisable() {
        enemyArmor.SetActive(false);
        percentText.gameObject.GetComponent<PowerBar>().playerPower -= 25;
        // Place audio clio code here.
    }

    // Shake the Canvas.
    public void canvasShake() {
        mainUI.DOShakePosition(3.5f, 45f, 100, 70f, true, false);
    }


    // =======================

    // SOUND EFFECTS:
    // NOTE: Laser Blast's audio source = Enemy-2nd game object
    // NOTEL Laser Hit's audio source = laserHitAS game object

    public void playSfxLaserBlast() {
        laserAudioSource.PlayOneShot(sfxLaserBlast, 1f);
    }

    public void playSfxLaserHit() {
        laserHitAudioSource.PlayOneShot(sfxLaserHit, 1f);
    }

}
