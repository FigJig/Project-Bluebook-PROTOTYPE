using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; // DoTween Class Library

public class targetDoTween : MonoBehaviour {

	public Transform uiTarget;
	public Transform[] moveTarget;
	public float moveDuration; // Determines the amount of time spent from moving to one object to another in seconds.
	public bool moveSnap;

	// Use this for initialization
	void Start () {
		
		// Establish a DoTween sequence
		// > This variable is used as a reference when coding a list of animation sequences below.
		Sequence targetSequence = DOTween.Sequence ();

		// NOTE: "Append" means to activate an "animation line" one by one in order.

		// TARGET SEQUENCE ORDER:
		// > Move the uiTarget's position to each of the moveTarget's array objects' local positions in order.
		targetSequence.Append (uiTarget.DOLocalMove(new Vector3(moveTarget[0].localPosition.x, moveTarget[0].localPosition.y,0),moveDuration,moveSnap));
		targetSequence.Append (uiTarget.DOLocalMove(new Vector3(moveTarget[1].localPosition.x, moveTarget[1].localPosition.y,0),moveDuration,moveSnap));
		targetSequence.Append (uiTarget.DOLocalMove(new Vector3(moveTarget[2].localPosition.x, moveTarget[2].localPosition.y,0),moveDuration,moveSnap));
		targetSequence.Append (uiTarget.DOLocalMove(new Vector3(moveTarget[3].localPosition.x, moveTarget[3].localPosition.y,0),moveDuration,moveSnap));
		targetSequence.Append (uiTarget.DOLocalMove(new Vector3(moveTarget[4].localPosition.x, moveTarget[4].localPosition.y,0),moveDuration,moveSnap));
		targetSequence.Append (uiTarget.DOLocalMove(new Vector3(moveTarget[5].localPosition.x, moveTarget[5].localPosition.y,0),moveDuration,moveSnap));
		targetSequence.Append (uiTarget.DOLocalMove(new Vector3(moveTarget[6].localPosition.x, moveTarget[6].localPosition.y,0),moveDuration,moveSnap));

		// Loop the above sequence x-number of times and determine the Loop Type
		// (LOOP TYPES: Incremental, Restart and Yoyo)
		targetSequence.SetLoops (9999, LoopType.Restart);
	}

}
