using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class End_Script : MonoBehaviour {

    public GameObject PlayerObject;
    public GameObject Ending_Canvas;


    void Start()
    {
        Ending_Canvas.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            Ending_Canvas.SetActive(true);
            PlayerObject.GetComponent<FirstPersonController>().enabled = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    public void LoadMainMenu_Level(string _LevelName)
    {

        SceneManager.LoadScene(_LevelName);


    }
}
