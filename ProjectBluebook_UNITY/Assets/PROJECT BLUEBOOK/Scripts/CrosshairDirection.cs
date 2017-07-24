using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairDirection : MonoBehaviour {

    public GameObject crosshair;
    public Text crosshairText;
    bool borderHit;
    public float coolDown;

	// Use this for initialization
	void Start () {
        borderHit = false;
        coolDown = 1f;
        crosshairText.gameObject.GetComponent<Text>().text = "Locate target";
    }
	
	// Update is called once per frame
	void Update () {
	 

        if (borderHit == false & CrosshairBehaviour.targetDetected == false)
        {
            crosshairText.gameObject.GetComponent<Text>().text = "Locate target";
        }

        if (borderHit == true)
        {
            coolDown -= Time.deltaTime;
            if (coolDown <= 0f)
            {
                borderHit = false;
                coolDown = 1f;
            }
        }
            
	}

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "CrosshairBorder")
        {
            borderHit = true;
            if (borderHit == true)
            {
                crosshairText.gameObject.GetComponent<Text>().text = "Leaving target area";
            }
        }

        if (other.gameObject.tag == "CrosshairReset")
        {
            borderHit = false;
            crosshair.transform.position = new Vector3(960, 700, 0);
            crosshairText.gameObject.GetComponent<Text>().text = "Locate target";
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "CrosshairBorder")
        {
            borderHit = false;
            //crosshair.gameObject.GetComponent<CrosshairBehaviour>().enabled = true;
            crosshairText.gameObject.GetComponent<Text>().text = "Locate target";
        }
    }


    IEnumerator CrosshairWarning ()
    {
        yield return new WaitForSeconds(1f);
        crosshairText.gameObject.GetComponent<Text>().text = "Locate target";
        borderHit = false;
        StopCoroutine("CrosshairWarning");
    }
}
