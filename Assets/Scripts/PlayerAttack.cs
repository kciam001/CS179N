using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackDamage = 5.0f;
    private float attackCooldown = 0.6f;
    private float timer;
    private bool canAttack = false;
    float projectileSpeed = 18.0f;
    public Collider coll;
    public GameObject projectile;
    GameObject magicAttack;
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
        if (timer < 0 && isAttacking)
        {

            canAttack = true;
            //this.gameObject.GetComponent<character_animator>().CheckAttack();
            timer = attackCooldown;
        }
            
        else
        {
            canAttack = false;
        }

    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Enemy" && canAttack)
        {
            coll.gameObject.GetComponent<AITest>().TakeDamage();
            coll.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            canAttack = false;
        }

    }
    public void MagicAttack()
    {

        this.GetComponent<character_animator>().TriggerChargeUse();
        Vector3 position = new Vector3(this.GetComponent<Transform>().position.x, this.GetComponent<Transform>().position.y + 1, this.GetComponent<Transform>().position.z);
        magicAttack = Instantiate(projectile, position, this.transform.rotation) as GameObject;
        magicAttack.transform.Rotate(0, 90, 0, Space.Self);
        if (magicAttack != null)
        {
            Rigidbody rb = magicAttack.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * projectileSpeed;
            Destroy(magicAttack, 3.0f);
        }
    }
}
