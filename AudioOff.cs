using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOff : MonoBehaviour {

    public Cross cross; //Cross 클래스에 있는 변수들을 이용하기 위해서 

	
	
	
	void Update () {

        if (Input.GetButtonUp("Fire1")) //마우스 오른쪽을 눌렀다가 때었다면,
        {
            cross.myAudioSource.enabled = false;    //cross에 멤버중 myAudioSource를 비활성화 하고,
            cross._animator.enabled = false;        //cross에 멤버중 _animator를 비활성화 한다.
        }

        else
        {
            cross.myAudioSource.enabled = true; //마우스 오르쪽 누르면 다시 사운드 활성화.
        }
	}
}
