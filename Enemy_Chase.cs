using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Chase : MonoBehaviour {

    private NavMeshAgent navagent;
    private Animator My_animator;

    private Player_health playerhealth;

    public int damage = 20;
    public Transform target;
    public float stopingDistance = 2f;
    public float delayBetweenAttack = 1.5f;
    public bool Chase_Target = true;
    private float AttackCoolDown;
    private float distanceFromPlayer;


	void Start () {
        navagent = GetComponent<NavMeshAgent>();
        My_animator = GetComponent<Animator>();
        navagent.stoppingDistance = stopingDistance;
        AttackCoolDown = Time.time;

        playerhealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_health>();
	}
	
	
	void Update () {

        Chasetarget();
	}

    void Chasetarget()
    {
        distanceFromPlayer = Vector3.Distance(target.position, transform.position);

        if (distanceFromPlayer >= stopingDistance)
        {
            Chase_Target = true;

        }

        else
        {
            Chase_Target = false;
            Attack();
        }

        if (Chase_Target)
        {
            navagent.SetDestination(target.position);
            My_animator.SetBool("IsChasing", true);
        }

        else
        {
            My_animator.SetBool("IsChasing", false);
        }

    }

    void Attack()
    {
        if (Time.time > AttackCoolDown)
        {
            playerhealth.Take_damage(damage);
            My_animator.SetTrigger("Attack");
            AttackCoolDown = Time.time + delayBetweenAttack;
        }

    }
    
}
