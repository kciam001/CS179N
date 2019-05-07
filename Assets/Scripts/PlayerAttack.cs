using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackDamage = 5.0f;
    private float attackCooldown = 0.5f;
    private float timer;
    private bool canAttack = false;
    public Collider coll;
    // Start is called before the first frame update
    void Start()
    {
        timer = attackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        bool isAttacking = this.gameObject.GetComponent<character_animator>().myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
        Debug.Log(canAttack);
        if (timer < 0 && isAttacking)
        {

            canAttack = true;
            this.gameObject.GetComponent<character_animator>().CheckAttack();
            timer = attackCooldown;
        }
            
        else
        {
            canAttack = false;
        }

    }

    void OnTriggerStay(Collider coll)
    {
        Debug.Log("Entered");
        if (coll.tag == "Enemy" && canAttack)
        {
            coll.gameObject.GetComponent<AITest>().TakeDamage();
            coll.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            canAttack = false;
        }

    }
}
