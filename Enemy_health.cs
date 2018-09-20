using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_health : MonoBehaviour {

    public int MAX_health = 100;    
    private int current_health;
  


	void Start () {

        current_health = MAX_health;
	}
	
	
	void Update () {
		
	}

    public void TakeDamage(int _damage)
    {
        current_health -= _damage;

        if (current_health == 0)
        {
            StartCoroutine(Die());
        }

        if (current_health > 0)
        { 
        StartCoroutine(Damaging());
        }


    }

    IEnumerator Die()
    {   
        yield return new WaitForSeconds(2.45f);
        Debug.Log("죽음");
        Destroy(gameObject);
    }

    IEnumerator Damaging()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log("맞는중");
    }
    
}
