using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
public class KeyPad : MonoBehaviour
{
    public string curPassword = "12345";    //비밀번호
    public string input;    //입력되는 비밀번호를 넣을 변수
    public bool onTrigger;  // boxcollider에 trigger를 판별하기 위한 bool변수
    public bool keypadScreen;   //trigger를 통해서 판별하여 keypadScreen을 온 또는 오프 를 판별 하는 bool 변수
    public Door door;   // 키패드로 정확한 비밀번호를 입력하면 Door스크립트에 있는 잠긴 문을 열기 위해서 참조할 변수
    public GameObject PlayerObject; // keypadScreen이 나타나면 캐릭터가 움직이지 않게 하기위한 GameObject 타입의 변수
    public GameObject Screen_text;  // Screen_text 변수는 GameObject에 TextMesh를 사용하기 위함
    public AudioClip Keypad_Button_sound1;  //입력되는 소리의 오디오 클립
    public AudioClip Keypad_Button_sound2;  //비밀번호를 지우게 되면 나오는 오디오 클립
    public AudioClip Unlocked_sound;    //정확한 비밀번호를 입력하기 되면 나오는 오디오 클립
    public AudioSource Source;

    public void OnTriggerEnter(Collider other)
    {
        onTrigger = true;   //캐릭터가 Box Collider에 들어옴

    }

    public void OnTriggerExit(Collider other)
    {
        onTrigger = false;      //캐릭터가 Box Collider에서 벗어남
        keypadScreen = false;   //캐릭터나 벗어나면 keypadScreen이 비활성화되어 없어짐
        input = ""; // Trigger에 다시 Enter 하거나 Exit하면 초기화 되도록 함 
    }


     public void Update()
    {
        if (input == curPassword)   //input 변수에 입력된 비밀번호가 curPassword와 일치한다면
        {

            door.isLooked = false;  //참조된 door 변수 에 있는 isLooked 의 값을 false로 하여 문이 열리게 연동함 
            Screen_text.GetComponent<TextMesh>().text = "Unlocked!!";   // 그리고 나서 TextMash를 이용하여서 Unlocked로 나타나게 표현
            Source.PlayOneShot(Unlocked_sound); // 비밀번호가 풀린 오디오 클립
            keypadScreen = false;   // keypadScreen을 비활성화
            onTrigger = true;   
            PlayerObject.GetComponent<FirstPersonController>().enabled = true; //비밀번호가 풀렸으니 캐릭터를 움직이게 활성화
            Cursor.lockState = CursorLockMode.Locked;   // 움직이지 않게 한 커서를 풀어줌
            Cursor.visible = false; // 마우스 커서를 사라지게 비활성화
            Destroy(this.gameObject);   
        }

        

    }


    public void OnGUI()
    {
        if (onTrigger)  // 트리거가 true 이면
        {
            GUI.Box(new Rect(0, 0, 200, 25), "Press 'E' to open keypad"); //GUI 박스가 화면 왼쪽 상단에 Press 'E' to open keypad 나타나게함
            if (Input.GetKeyDown(KeyCode.E))    //E키를 누르면
            {
                                        
                keypadScreen = true;   // keypadScreen 활성화 하고 onTrigger를 비활성화
                onTrigger = false;
                PlayerObject.GetComponent<FirstPersonController>().enabled = false; //비밀번호를 풀때 캐릭터가 움직이지 않게 하기 위해서 비활성화 시킴
                Cursor.lockState = CursorLockMode.None; //커서의 상태를 Lock시킴
                Cursor.visible = true;  // 마우스 커서를 보이게 하여 비밀번호를 풀때 화면이 움직이지 않음
            }

            else if (Input.GetButtonDown("Cancel")) //ESC버튼을 누르면
            {
                keypadScreen = false;   
                onTrigger = true;
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                PlayerObject.GetComponent<FirstPersonController>().enabled = true;
                
                
            }
        }

        if (keypadScreen)   // keypadScreen이 활성화 된다면
        {
            GUI.Box(new Rect(0, 0, 320, 450), "");          //GUI박스와 GUI버튼들을 만들어 내고 input 변수에 
            GUI.Box(new Rect(5, 5, 310, 25), input);        //비밀번호를 입력 하게 하면서 버튼을 누를 시 오디오 클립이 플레이 되도록 함

            if(GUI.Button(new Rect(5, 35, 100, 100), "1"))  //그리고 input변수를 선언 하였을 때 string으로 선언 한 이유는
            {                                               // 숫자값이 예를들어 12345이렇게 나열해서 나타내기 위해서 string으로 숫자를 
                Source.PlayOneShot(Keypad_Button_sound1);   //나타내야지 문자로 변환되어 숫자들이 더해지지 않게 나타낼수 있다.
                input = input + "1";
                                                            //int로 input변수를 처음에 선언 하여서 계속 비밀번호들끼리 더해지는 현상이 
            }                                               //발생 하여 오류아닌 오류가 발생 하였음
                                                            // GUI 버튼중에서 C버튼은 입력되었던 숫자들을 취소 시키서 다시 처음부터 
            if (GUI.Button(new Rect(110, 35, 100, 100), "2"))   //입력 되게 초기화 되도록 하게 나타냄
            {
                Source.PlayOneShot(Keypad_Button_sound1);
                input = input + "2";

            }

            if(GUI.Button(new Rect(215, 35, 100, 100), "3"))
            {
                Source.PlayOneShot(Keypad_Button_sound1);
                input = input + "3";
            }


            if (GUI.Button(new Rect(5, 140, 100, 100), "4"))
            {
                Source.PlayOneShot(Keypad_Button_sound1);
                input = input + "4";

            }

            if (GUI.Button(new Rect(110, 140, 100, 100), "5"))
            {
                Source.PlayOneShot(Keypad_Button_sound1);
                input = input + "5";

            }

            if (GUI.Button(new Rect(215, 140, 100, 100), "6"))
            {
                Source.PlayOneShot(Keypad_Button_sound1);
                input = input + "6";
            }


            if (GUI.Button(new Rect(5, 245, 100, 100), "7"))
            {
                Source.PlayOneShot(Keypad_Button_sound1);
                input = input + "7";

            }

            if (GUI.Button(new Rect(110, 245, 100, 100), "8"))
            {
                Source.PlayOneShot(Keypad_Button_sound1);
                input = input + "8";

            }

            if (GUI.Button(new Rect(215, 245, 100, 100), "9"))
            {
                Source.PlayOneShot(Keypad_Button_sound1);
                input = input + "9";
            }

            if (GUI.Button(new Rect(110, 350, 100, 100), "Cancel"))
            {
                Source.PlayOneShot(Keypad_Button_sound2);
                input = "";

            }

        }
    }

}
