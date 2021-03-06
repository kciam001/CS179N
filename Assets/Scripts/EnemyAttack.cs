﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private float damage;
    private float stayCount = 0.0f;
    string enemyName;
    public GameObject projectile;
    float projectileSpeed = 12.0f;
    GameObject fireball;
    // Start is called before the first frame update
    void Start()
    {
        enemyName = this.name;
        SetDamage();

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
    void SetDamage()
    {
        if (enemyName.Contains("Grunt"))
        {
            damage = 3.0f;
        }
        else if (enemyName.Contains("TrollGiant"))
        {
            damage = 5.0f;
        }
        else if (enemyName.Contains("Lich"))
        {
            damage = 1.0f;
        }
        else if (enemyName.Contains("Skeleton"))
        {
            damage = 1.5f;
        }

    }
    public void LichAttack()
    {


        Vector3 position = new Vector3(this.GetComponent<Transform>().position.x, this.GetComponent<Transform>().position.y + 1, this.GetComponent<Transform>().position.z);
        fireball = Instantiate(projectile, position, Quaternion.identity) as GameObject;
        if (fireball != null)
        {
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;
            Destroy(fireball, 3.0f);
        }
    }
}
