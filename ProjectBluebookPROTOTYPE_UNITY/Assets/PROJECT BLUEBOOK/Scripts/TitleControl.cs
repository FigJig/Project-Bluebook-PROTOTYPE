using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleControl : MonoBehaviour {

    public Text creditsText;

    Text titleText;

	// Use this for initialization
	void Start () {
        creditsText.gameObject.GetComponent<Text>();

        titleText = gameObject.GetComponent<Text>();

        StartCoroutine("titleAnim");
	}
	
	// Update is called once per frame
	void Update () {
		
        

	}

    IEnumerator titleAnim()
    {
        yield return new WaitForSeconds(2f);
        titleText.enabled = true;
        yield return new WaitForSeconds(1f);
        creditsText.gameObject.GetComponent<Text>().text = "DEVELOPED BY:";
        yield return new WaitForSeconds(1f);
        creditsText.gameObject.GetComponent<Text>().text += "\nTrent Davies";
        yield return new WaitForSeconds(1f);
        creditsText.gameObject.GetComponent<Text>().text += "\nSimon Tran";
        yield return new WaitForSeconds(1f);
        creditsText.gameObject.GetComponent<Text>().text += "\nAdrian Satrianugraha";
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
