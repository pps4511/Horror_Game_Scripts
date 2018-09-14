using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoTrigger : MonoBehaviour {

    public AudioSource Piano_Audio_Source; //피아노의 위치로 부터 소리가 나오는 변수.
    public AudioClip Piano_Audio; //피아노에서 나오는 오디오 클립 변수.
    public Light Piano_SpotLight; //피아노 오디오와 함께 스팟라이트를 키기위한 변수.
    private bool has_played_Audio; //bool값을 이용하여 오디오를 키기 위한 변수. 
    

    private void OnTriggerEnter(Collider other)                     //OnTriggerEnter함수를 이용하여 other이라는 collider의
    {
        if (other.CompareTag("Player")&& has_played_Audio==false)   //tag의 이름들 중"Player"라는 것을 찾고 has_played_Audio 값이 false 이면 
        {
            Piano_Audio_Source.PlayOneShot(Piano_Audio);            // 피아노에서 오디오클립이 한번만 실행되도록 하였습니다.
            has_played_Audio = true;                                
            Piano_SpotLight.enabled = true;                         //그리고 오디오클립이 실행과 동시에 스팟라이트를 true로 하여 밝게 하였습니다.
            
        }
    }

}
