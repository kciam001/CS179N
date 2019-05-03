using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackDamage = 5.0f;
    private float attackCooldown = 3.0f;
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
        if(timer < 0){
            if(Input.GetMouseButtonDown(0)){
                canAttack = true;
                timer = attackCooldown;
            }
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        Debug.Log("Entered");
        if (coll.tag == "Enemy" && canAttack)
        {
            coll.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            canAttack = false;
        }

    }
}
