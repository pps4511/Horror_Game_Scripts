using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour {

    public int damage = 20;     
    public float range = 50f;
    
    public Animator _animator;  //십자가로 공격시, 효과를 주기 위한 Animator.
    private Transform mainCamera;   //십자가 모델을 pickup하려 할때, 오브젝트에 메인 카메라의 태그가 있는지 나타내주기 위한 것 입니다.
    public AudioSource myAudioSource;   //오디오 소스와 클립은 십가가로 공격시, 공격사운드로 효과를 주기 위해 만들었습니다.
    public AudioClip magicSound;
    
	void Start () {
        myAudioSource = GetComponent<AudioSource>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
       //오브젝트에 태그명이 "MainCamera"가 있는지 나타냄.

	}
	
	// Update is called once per frame
	void Update () {


        if (Input.GetButton("Fire1"))//마우스 왼쪽을 눌르는 동안,
        {
            
            Magic();    

        }

        if (Input.GetButtonDown("Fire1"))//마우스 왼쪽을 한번 눌렀다면,
        {
            myAudioSource.PlayOneShot(magicSound);//십자가 공격사운드 효과 한번만 출력.

        }
	}


    void Magic()
    {
        Ray ray = new Ray(mainCamera.position, mainCamera.forward);// Ray구조의 변수 ray를 생성.
        RaycastHit hit;// hit는 ray를 통해 어떤 오브젝트의 충돌 정보 추출.


        if (Physics.Raycast(ray, out hit, range))// ray를 통해서 range범위에 충돌한 오브젝트에 정보가 있다면,
        {
            if (hit.collider.CompareTag("Enemy"))// 그게 태그명이"Enemy"이면,
            {

                hit.collider.GetComponent<Enemy_health>().TakeDamage(damage);
                

            }
                
        }

     
        _animator.enabled = true;   //애니메이터를 활성화.
    }

    

    
}
