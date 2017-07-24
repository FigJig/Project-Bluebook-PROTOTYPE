using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CAMERA SHAKE:
// SOURCE: https://gist.github.com/ftvs/5822103
// SOURCE DETAILS: User "nicotroia" comment, 8 Aug 2016
// NOTE: Since this script uses a static function, it can be called from anywhere at any other script.

// SCRIPT USAGE:
// 1. Attach this script to a game object
// 2. On any other script that you wish you use CameraShake, use the following code line:
//    CameraShake.Shake(floatNumber1, floatNumber2);

//   where...  floatNumber1 = float Duration
//   where...  floatNumber2 = float Amount

//   e.g. CameraShake.Shake(0.25f, 4f);

public class CameraShake : MonoBehaviour {

    public static CameraShake instance;

    private Vector3 _originalPos;
    private float _timeAtCurrentFrame;
    private float _timeAtLastFrame;
    private float _fakeDelta;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        // Calculate a fake delta time, so we can Shake while game is paused.
        _timeAtCurrentFrame = Time.realtimeSinceStartup;
        _fakeDelta = _timeAtCurrentFrame - _timeAtLastFrame;
        _timeAtLastFrame = _timeAtCurrentFrame;
    }

    public static void Shake(float duration, float amount)
    {
        instance._originalPos = instance.gameObject.transform.localPosition;
        instance.StopAllCoroutines();
        instance.StartCoroutine(instance.cShake(duration, amount));
    }

    public IEnumerator cShake(float duration, float amount)
    {
        float endTime = Time.time + duration;

        while (duration > 0)
        {
            transform.localPosition = _originalPos + Random.insideUnitSphere * amount;

            duration -= _fakeDelta;

            yield return null;
        }

        transform.localPosition = _originalPos;
    }


}
