using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player_health : MonoBehaviour {

    public int Player_Maxhealth = 100;
    private int Player_Currenthealth = 0;
    
  
    void Start () {
        Player_Currenthealth = Player_Maxhealth;
       
    }


    public void Take_damage(int Damage)
    {
        Player_Currenthealth -= Damage;

        if (Player_Currenthealth == 0)
        {
           Die_And_LoadLevel();
        }

    }


    private void Die_And_LoadLevel()
    {

        Debug.Log("Game_Over");
        SceneManager.LoadScene("Scene_GameOver");


    }

 
}
