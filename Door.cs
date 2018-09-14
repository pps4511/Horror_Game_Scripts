using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {
    
    public bool open = false; // door의 상태 값을 저장 하기 위해서 입니다.
    public bool isLooked = false;
    public float doorOpenAngle = 90f;   //문을 90도로 열기위한 변수
    public float doorCloseAngle = 0f;   //열려진 문들을 닫기위한 변수
    public float smooth = 8f; // 회전의 속도를 8초로 초기화 하였습니다.
    public bool front = false;  // bool로 frontTrigger에 도달했는지에 대한 여부를 확인하기 위한 변수
    public bool back = false;   // bool로 backTrigger에 도달했는지에 대한 여부를 확인하기 위한 변수
    private AudioSource doorAudioSource;    // door에서 오디오가 나오는 나타나기위한 변수
    private bool has_opened_completely;     //  bool로 문이 완벽하게 열렸는지에 대한 여부 확인 변수
    public AudioClip doorAudioOpen;         //  door 오디오 클립(열린소리)
    public AudioClip doorAudioLooked;       //  door 오디오 클립(잠긴소리)

     void Start()
    {
        doorAudioSource = GetComponent<AudioSource>();  
    }

    public void ChangeDoorState()
    {
        if (isLooked != true)
        {
            open = !open;   //문이 열려있거나 닫혀있는 상태를 그때그때 바꿀수 있게 하기 위해서 입니다.

            if (doorAudioSource != null)    // 오디오소스가 null이 아니면 오디오 클립 한번만 실행.
            {
                doorAudioSource.PlayOneShot(doorAudioOpen);

            }

        }

        else
        {
            LookedSound();
        }
    
        
    }

    void LookedSound()
    {
        doorAudioSource.PlayOneShot(doorAudioLooked);

    }
	
	// Update is called once per frame
	void Update () {

        if (open)   //open변수에 값이 true이면 
        {
            if (front && has_opened_completely == false)  //FrontTrigger 에서 문을 열려고 할 경우
            {

                //문을 옆니다.

                Quaternion targetRotationOpen = Quaternion.Euler(0, -doorOpenAngle, 0); //쿼터니언구조체에 있는 Euer을 이용하여 y축에 값을 -doorOpenAngle(90)으로 줘서 회전을 주고
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);//transform.localRotation에는 쿼터니언에 있는 Slerp함수를 이용하여 Euer함수로 회전하는것을 부드럽게 하기위해서 입니다.

                if (transform.localRotation == targetRotationOpen)  // 두값이 일치하면 완벽하게 문이 열렸다는 것을 bool로 표현.
                {
                    has_opened_completely = true;       //문이 완벽하게 열렸다는 것을 bool값 true로 변환

                }
            }

            else if (back && has_opened_completely == false)  //backTrigger에서 문을 열려고 할 경우
            {
                //문을 옆니다.
                Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);

                if (transform.localRotation == targetRotationOpen)
                {
                    has_opened_completely = true;       //문이 완벽하게 열렸다는 것을 bool값 true로 변환

                }
            }
        }
        else    //open이 false이면
        {
            //문을 닫습니다.

            Quaternion targetRotationClose = Quaternion.Euler(0, doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationClose, smooth * Time.deltaTime);
            has_opened_completely = false;
        }



      
	}
}
