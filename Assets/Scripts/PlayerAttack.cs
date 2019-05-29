using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float attackDamage = 5.0f;
    private float kickDamage = 2.0f; // *5 for super kick
    private float attackCooldown = 0.6f;
    private float kickCooldown = 1.2f;
    private float kickForce = -2000; // *5 for super kick
    private float attackTimer;
    private float kickTimer;
    private bool canAttack = false;
    private bool canKick = false;
    public bool superKick = false;
    public int superKickCharges = 0;
    float projectileSpeed = 18.0f;
    public Collider coll;
    public GameObject projectile;
    public GameObject kickVFX;
    GameObject magicAttack;
    // Start is called before the first frame update
    void Start()
    {
        attackTimer = attackCooldown;
        kickTimer = kickCooldown;
    }

    // Update is called once per frame
    void Update() 
    {
        attackTimer -= Time.deltaTime;
        kickTimer -= Time.deltaTime;
        bool isAttacking = this.gameObject.GetComponent<character_animator>().myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
        bool isKicking = this.gameObject.GetComponent<character_animator>().myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Kick");

        if (attackTimer < 0 && isAttacking)
        {

            canAttack = true;
            //this.gameObject.GetComponent<character_animator>().CheckAttack();
            attackTimer = attackCooldown;
        }
            
        else
        {
            canAttack = false;
        }
        if (kickTimer < 0 && isKicking)
        {
      

            canKick = true;
            //this.gameObject.GetComponent<character_animator>().CheckAttack();
            kickTimer = kickCooldown;
        }

        else
        {
            canKick = false;
        }


    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Enemy" && canAttack)
        {
            coll.gameObject.GetComponent<AITest>().TakeDamage();
            coll.gameObject.GetComponent<EnemyHealth>().TakeDamage(attackDamage, false);
            canAttack = false;
        }
   
        if (coll.tag == "Enemy" && canKick)
        {
            if(superKick)
            {
                kickDamage =10.0f;
                kickForce = -8000f;
                GameObject VFX = Instantiate(kickVFX, coll.transform.position, coll.transform.rotation);
                Destroy(VFX, 1f);
                superKickCharges -= 1;

                if(superKickCharges <= 0)
                {
                    ResetSuperKick();
                }
                this.GetComponent<character>().SpecialPowerHUD();
            }
            else
            {
                kickDamage = 2.0f;
                kickForce = -2000f;
            }

            //damage
            coll.gameObject.GetComponent<AITest>().TakeDamage();
            coll.gameObject.GetComponent<EnemyHealth>().TakeDamage(kickDamage, false);

            //knockback
            Vector3 moveDirection = this.GetComponent<Rigidbody>().transform.position - coll.gameObject.GetComponent<Rigidbody>().transform.position;
            coll.gameObject.GetComponent<Rigidbody>().AddForce(moveDirection.normalized * kickForce);

           

            canKick = false;
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
    public void SuperKickPowerUp()
    {
        superKick = true;
        superKickCharges = 5;
        this.GetComponent<character>().SpecialPowerHUD();
    }
    public void ResetSuperKick()
    {
        superKick = false;
        superKickCharges = 0;
    }
}
