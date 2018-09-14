using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class Safe : MonoBehaviour {

    public Canvas Safe_Canvas;
    public GameObject PlayerObject;
    public float doorOpenAngle = 90f;
    public float Smooth = 8f;
    private int number01 = 1;
    private int number02 = 1;
    private int number03 = 1;
    private int number04 = 1;

    public Text textnumber01;
    public Text textnumber02;
    public Text textnumber03;
    public Text textnumber04;

    public bool opened;

    void Start()
    {

        opened = false;
        Safe_Canvas.enabled = false;    
    }


    public void ShowSafeCanvas() {

        Safe_Canvas.enabled = true;
        PlayerObject.GetComponent<FirstPersonController>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
	
	
	// Update is called once per frame
	void Update () {




        if (Input.GetButtonDown("Cancel"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            PlayerObject.GetComponent<FirstPersonController>().enabled = true;

            Safe_Canvas.enabled = false; 
        }

        if (number01 == 1 && number02 == 1 && number03 == 1 && number04 == 2)
        {
            opened = true;

        }

        if (opened == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            PlayerObject.GetComponent<FirstPersonController>().enabled = true;

            Safe_Canvas.enabled = false;

            gameObject.layer = 0; 
            UnlockSafe();

        }
	}


    void UnlockSafe()
    {

        Quaternion targetRotationOpen = Quaternion.Euler(0, 0, doorOpenAngle); 
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, Smooth * Time.deltaTime);
    }

    public void IncreaseNumber(int _number)
    {
        if (_number == 1)
        {
            number01++;
            textnumber01.text = number01.ToString();

            if (number01 > 9)
            {
                number01 = 1;
                textnumber01.text = number01.ToString();


            }
        }

         

        else if (_number == 2)
        {
            number02++;
            textnumber02.text = number02.ToString();

            if (number02 > 9)
            {
                number02 = 1;
                textnumber02.text = number02.ToString();


            }
        }

         

        else if (_number == 3)
        {
            number03++;
            textnumber03.text = number03.ToString();

            if (number03 > 9)
            {
                number03 = 1;
                textnumber03.text = number03.ToString();


            }
        }

         

        else if (_number == 4)
        {
            number04++;
            textnumber04.text = number04.ToString();

            if (number04 > 9)
            {
                number04 = 1;
                textnumber04.text = number04.ToString();


            }
        }

         

    }


    public void DecreaseNumber(int _number)
    {
        if (_number == 1)
        {
            number01--;
            textnumber01.text = number01.ToString();

            if (number01 <1)
            {
                number01 = 9;
                textnumber01.text = number01.ToString();


            }
        }



        else if (_number == 2)
        {
            number02--;
            textnumber02.text = number02.ToString();

            if (number02 < 1)
            {
                number02 = 9;
                textnumber02.text = number02.ToString();


            }
        }



        else if (_number == 3)
        {
            number03--;
            textnumber03.text = number03.ToString();

            if (number03 < 1)
            {
                number03 = 9;
                textnumber03.text = number03.ToString();


            }
        }



        else if (_number == 4)
        {
            number04--;
            textnumber04.text = number04.ToString();

            if (number04 < 1)
            {
                number04 = 9;
                textnumber04.text = number04.ToString();


            }
        }



    }


}
