using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {


    public AudioSource door_open_sound;
    public AudioSource door_close_sound;
    public AudioClip exit_sound;
    public AudioClip start_sound;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        door_open_sound = door_open_sound.GetComponent<AudioSource>();
    }
    public void LoadLevel(string _levelName)
    {

        StartCoroutine(Start_Game(_levelName));

    }

    IEnumerator Start_Game(string _levelName)
    {
        door_open_sound.PlayOneShot(start_sound);
        yield return StartCoroutine(Wait(3.1f));
             SceneManager.LoadScene(_levelName);
    }


    public void Quit()
    {
        StartCoroutine(_Quit());
        

    }

    IEnumerator _Quit()
    {
        door_close_sound.PlayOneShot(exit_sound);
        yield return StartCoroutine(Wait(5.3f));
        Application.Quit();
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("Wait메소드에서" + time + "만큼 기다리고 나감.");
    }
}
