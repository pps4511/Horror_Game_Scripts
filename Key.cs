using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Key : MonoBehaviour {

    public Door Mydoor;     //Door 클래스에 있는 함수나 변수들을 참조 하기위해서 Mydoor라는 변수를 선언.
    public GameObject key_text;     //Key_text는 게임 내에서 key를 얻었을때 자막이 나오게 하기 위해서 만든 변수. 
    public AudioSource KeyAudioSource;  //key를 얻었을때, key객체에서 오디오가 나오도록 하기 위한 컨포넌트 타입의 변수.
    public AudioClip KeyAudioClip;  //AudioSource 컨포넌트에 있는 오디오(keyAudioClip)클립을 실행 하기 위한 변수.
	
	

     void Start()   //start()함수에는 컨포넌트에 있는 오디오 소스와 text를 게임을 시작하 였을때 불어오기 위해서 초기화. 
    {
        KeyAudioSource = GetComponent<AudioSource>();   
        key_text.GetComponent<Text>();
    }

    public void UnlockDoor()    //UnlockDoor()함수에는 key를 얻었을 때
    {
        Mydoor.isLooked = false;    // MyDoor스크립트를 가지고 있는 객체에 isLooked 변수의 상태를 false 바뀌게 함.
        KeyAudioSource.PlayOneShot(KeyAudioClip);   // key에서 오디오 클립이 한번만 실행되게 함.
        key_text.GetComponent<Text>().enabled = true;   // Key_text 객체에 text 컨포넌트를 true로 하여 활성화 시킴.
        key_text.GetComponent<Text>().text = "yeah I get some master key."; // 활성화된 text에 적혀진 내용을 출력.
        StartCoroutine("waitforDestruct");  //startCorutine()함수를 사용하여 IEnumerator타입 WaitforDestruct()함수를 불러옴.
    }

    IEnumerator waitforDestruct()   //불러진 waitforDestruct()함수에는 전에 활성화 되었던 text들을 시간간격을 주어서 비활성화 시킴.
    {                               //Enumerator타입은 일반 함수들과는 달리 WaitForSeconds함수 라는 시간 간격을 줄수 있는 사용할수 있다. 
        yield return new WaitForSeconds(1f);
        key_text.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.25f);
        key_text.GetComponent<Text>().enabled = false;
        Destroy(this.gameObject);   //key를 얻고 나서 책상에 key객체를 사라지게 하기 위해서 Destory함수를 이용함.
        

    }
}
