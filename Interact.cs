using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//interact를 하기위해서는 유니티 엔지에서 UI를 사용하겠다는 것을 선언 해야합니다.
public class Interact : MonoBehaviour {

    public string InteractButton;   
    public float InteractDistance = 3f;
    public LayerMask InteractLayer;
    public Image InteractIcon;
    public bool is_Interacting;
    public Text text;
    
	void Start () {

        if (is_Interacting  !=  null)
        {
            InteractIcon.enabled = false;
            text.enabled = false;
        }
	}
	
	
	void Update () {
        
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit, InteractDistance,InteractLayer))
        {

            if (is_Interacting==false)
            {
                    
                if (InteractIcon!=null)
                {
                    InteractIcon.enabled = true;
                    text.enabled = true;
                }
                

                if (Input.GetButtonDown(InteractButton))
                {

                    if (hit.collider.CompareTag("Door"))
                    {

                        hit.collider.GetComponent<Door>().ChangeDoorState();
                    }

                    else if (hit.collider.CompareTag("Key"))
                    {

                        hit.collider.GetComponent<Key>().UnlockDoor();

                    }

                    else if (hit.collider.CompareTag("Safe"))
                    {
                        hit.collider.GetComponent<Safe>().ShowSafeCanvas();

                    }

                    else if (hit.collider.CompareTag("Note"))
                    {
                        hit.collider.GetComponent<Note>().ShowNoteImage();

                    }

                    else if (hit.collider.CompareTag("Password"))
                    {
                        hit.collider.GetComponent<Password>().ShowPasswordImage();

                    }


                    else if (hit.collider.CompareTag("Cross"))
                    {
                        hit.collider.GetComponent<CrossPickUp>().PickupCross();

                    }

                  
                }

            }
        }
        else 
        {
            InteractIcon.enabled = false;
            text.enabled = false;
        }

                    }
}
