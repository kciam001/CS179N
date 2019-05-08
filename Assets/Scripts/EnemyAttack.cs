﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float damage;
    private float stayCount = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        damage = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player"){
            if(stayCount > 0.5f){

                bool isAttacking = this.gameObject.GetComponent<AITest>().anim.GetCurrentAnimatorStateInfo(0).IsName("Attack01") || 
                                       this.gameObject.GetComponent<AITest>().anim.GetCurrentAnimatorStateInfo(0).IsName("Attack02");
                if (isAttacking)
                {
                    //Debug.Log("damage");
                    other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);

                    other.gameObject.GetComponent<character_animator>().TakeDamage();

                }
                stayCount = 0.0f;
            }
            else{
                stayCount += Time.deltaTime;
            }
        }
        
    }
}
