using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class Note : MonoBehaviour {

    public Image Note_Image;
    public GameObject HideNoteButton;
    public GameObject PlayerObject;
    public AudioClip pickUP;
    public AudioClip putawaySound;
	
	void Start () {
        Note_Image.enabled = false;
        HideNoteButton.SetActive(false); 
	}


    public void ShowNoteImage()
    {
        Note_Image.enabled = true;
        GetComponent<AudioSource>().PlayOneShot(pickUP);

        HideNoteButton.SetActive(true);
        PlayerObject.GetComponent<FirstPersonController>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void HideNoteImage()
    {
        Note_Image.enabled = false;
        GetComponent<AudioSource>().PlayOneShot(putawaySound);
        HideNoteButton.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerObject.GetComponent<FirstPersonController>().enabled = true;
    }
}
