using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour {

    public Door door;    //Door클래스에 있는것들과 연동하기 위해서 참조하였습니다.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //Player인지 식별되었다면 front는 false back은 true 유지.
        {
            door.front = false;
            door.back = true;
        }
    }
}
