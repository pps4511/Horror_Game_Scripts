using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Front : MonoBehaviour {

    public Door door;   //Door클래스에 있는 멤버들을 외부에서 접근하기 위해서 사용하였습니다.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //Player인지 식별되었다면 front는 true back은 false 유지.
        {
            door.front = true;  
            door.back = false;
        }
    }
}
