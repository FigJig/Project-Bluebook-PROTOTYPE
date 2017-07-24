using UnityEngine;
using System.Collections;

public class TextureScrolling : MonoBehaviour 
{
	public float scrollSpeed = 0.5f;
	float offset;

	void Update ()
	{
		offset += (Time.deltaTime*scrollSpeed)/10.0f;
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
	}
}