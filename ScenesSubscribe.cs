using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScenesSubscribe : MonoBehaviour {

    
    public GameObject Canvas;
	void Start () {
        Canvas.GetComponent<Text>().enabled = false;
        StartCoroutine(Scene_sub());
        
	}


    IEnumerator Scene_sub()
    {
        yield return new WaitForSeconds(1.5f);
        Canvas.GetComponent<Text>().enabled = true;
        Canvas.GetComponent<Text>().text = "I need to get out of here";
        yield return new WaitForSeconds(2.0f);
        Canvas.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1.5f);
        Canvas.GetComponent<Text>().enabled = false;
    }

    IEnumerator Scene_Pickup_key()
    {
        Canvas.GetComponent<Text>().enabled = true;
        Canvas.GetComponent<Text>().text = "yeah I get some master key.";
        yield return new WaitForSeconds(2.0f);
        Canvas.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(1.5f);
        Canvas.GetComponent<Text>().enabled = false;
    }
}
