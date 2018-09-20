using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour {


    public Light flashLight;    //객체에 플래쉬 라이트 컴포넌트.
    public AudioSource flashLightsound;//객체에 있는 오디오 소스가 오디오 클립들을 한번씩 동작하게 하기위한 오디오 클립들.
    public AudioClip Lightsound_On; //플래쉬 온 오디오 클립
    public AudioClip Lightsound_Off;//플래쉬 오프 오디오 클립
    private bool isActive;

	// Use this for initialization
	void Start () {
        isActive = true; //플래쉬를 켜기 위해서 F키를 눌렀을때 플래쉬에 상태에 따라 플래쉬를 on할지 off할지를 판단하기 위한 bool 변수.(처음 게임시작하였을때, 플래쉬는 켜지게 start함수에서 설정해놓았습니다.)
       
	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetKeyDown(KeyCode.F)) {

            if (isActive == false) { //f키를 눌렀을때,  isActive 가 false 이면, 라이트를 키고 

                flashLight.enabled = true; 
                isActive = true;    //isActive bool변수를 true 바꾸게 하여 다음에 f키를 또눌렀을때 라이트를 끄게 하기 위해서 입니다.
                flashLightsound.PlayOneShot(Lightsound_On);
            }

            else if (isActive == true) {    //isActive 가 true였을때, 라이트를 끄고 

                flashLight.enabled = false;
                isActive = false;   //isActive를 false로 바꾸어 다음에 f키를 눌렀을때 끄게 하기 위해서 이렇게 작성 하였습니다. 
                flashLightsound.PlayOneShot(Lightsound_Off);
            }

        }
	}
}
