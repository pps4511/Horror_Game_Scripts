using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossPickUp : MonoBehaviour {

    public AudioClip PickupSound;//십자가를 짚어들면 사운드가 나오도록 하기위함
    public GameObject Cross; // 인게임에서 캐릭터가 무기로 사용되는 진짜 십자가
    public GameObject Zombie; // 인게임에서 실제 공격하는 실제 좀비 오브젝트를 참조
    public GameObject Zombie_world; //욕조에 있는 움직임이 없는 좀비 오브젝트 참조

    public void PickupCross()
    {
        GetComponent<AudioSource>().PlayOneShot(PickupSound);
        Cross.SetActive(true);  //실제 공격을 할 수 있는 십자가를 활성화 시킴
        Destroy(gameObject, PickupSound.length);    //십자가가 활성화 되자마자 십자가 모델 오브젝트를 없앰
        Zombie_world.SetActive(false);  //욕조에 있는 움직임이 없는 좀비 오브젝트가 비활성화됨
        Zombie.SetActive(true); //십자가를 들자마자 실제로 캐릭터를 공격하는 좀비 오브젝트가 활성화되어 나타남
        
    }
}
