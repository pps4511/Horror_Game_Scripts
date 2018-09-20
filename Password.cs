using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class Password : MonoBehaviour {

    public Image Password_Image;
    public GameObject HideButton;
    public GameObject PlayerObject;
    public AudioClip PickupSound;
    public AudioClip PutDownSound;


    void Start()
    {
        Password_Image.enabled = false;
        HideButton.SetActive(false);
    }

    public void ShowPasswordImage()
    {
        Password_Image.enabled = true;
        HideButton.SetActive(true);
        GetComponent<AudioSource>().PlayOneShot(PickupSound);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        PlayerObject.GetComponent<FirstPersonController>().enabled = false;
    }

    public void HidePasswordImage()
    {
        Password_Image.enabled = false;
        GetComponent<AudioSource>().PlayOneShot(PutDownSound);
        HideButton.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerObject.GetComponent<FirstPersonController>().enabled = true;
    }
}
