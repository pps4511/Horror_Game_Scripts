using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver_Scene : MonoBehaviour
{
    public AudioSource Source;
    public AudioClip [] GameOverSounds;
    
    void Start()
    {
        Source = Source.GetComponent<AudioSource>();
        Source.clip = GameOverSounds[0];
        Source.PlayOneShot(GameOverSounds[0]);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    


    public void LoadLevel(string _levelName)                         
                                                                    
    {                                                               
                                                                    
                                            
        StartCoroutine(Scene_Change_to_Continue(_levelName));                                                                                                     
        


    }

    IEnumerator Scene_Change_to_Continue(string _levelName)
    {
        Source.clip = GameOverSounds[1];
        Source.PlayOneShot(GameOverSounds[1]);
        yield return StartCoroutine(WaitFor(3.4f));
        SceneManager.LoadScene(_levelName);


    }

    public void LoadMainMenu_Level(string _LevelName)
    {
        
        StartCoroutine(Scene_Change_to_MainMenu(_LevelName));
        

    }

IEnumerator Scene_Change_to_MainMenu(string _LevelName)
    {
        Source.clip = GameOverSounds[2];
        Source.PlayOneShot(GameOverSounds[2]);
        yield return StartCoroutine(WaitFor(5.3f));
        SceneManager.LoadScene(_LevelName);
    }





    IEnumerator WaitFor(float time)
    {
        Debug.Log("WaitFor메소드 들어옴");
        yield return new WaitForSeconds(time);
        Debug.Log("WaitFor메소드에서" +time+"초 기다리고 나감");
    }









}
