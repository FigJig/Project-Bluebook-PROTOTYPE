using UnityEngine;
using System.Collections;

public class RotateObject : MonoBehaviour {

	// USAGE:
	// Simply attach the script to the object you wish to rotate with code.

	// VARIABLES:
	// Rotation Speed: Affects the speed of the Offsets
	// xyz Offset: Determines the rotation axis of the object and its base speed.

	public float rotationSpeed;
	public float xOffset;
	public float yOffset;
	public float zOffset;


	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		// Rotate the pivot
		transform.Rotate(xOffset * rotationSpeed, yOffset * rotationSpeed, zOffset * rotationSpeed * Time.deltaTime);
	}
}
