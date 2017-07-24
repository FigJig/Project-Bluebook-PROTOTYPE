using UnityEngine;
using System.Collections;

public class SinMovement : MonoBehaviour {

 public float horizontalSpeed;
 public float verticalSpeed;
 public float amplitude;
 
 private Vector3 startPosition;
 private Vector3 tempPosition;

 void Start () 
  {
		startPosition = transform.position;
		tempPosition = transform.position;
 }
 
 void FixedUpdate () 
  {
  tempPosition.x += horizontalSpeed;
  tempPosition.y = Mathf.Sin(Time.realtimeSinceStartup * verticalSpeed)* amplitude + startPosition.y;
  transform.position = tempPosition;
 }
}