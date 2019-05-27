using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    private float projectileDamage = 7.0f;
    public GameObject explosionVFX;
    void OnTriggerEnter(Collider other)
    {
        if (this.name.Contains("Fireball"))
        {
            if (other.tag != "Enemy" && other.tag != "AttackBox" && other.tag != "Projectile")
            {
                if (other.tag == "Player")
                {
                    other.gameObject.GetComponent<PlayerHealth>().TakeDamage(projectileDamage);
                    other.gameObject.GetComponent<character_animator>().TakeDamage();
                }

                if (this != null)
                {
                    Destroy(gameObject);
                }
            }
        }
        if(this.name.Contains("MagicAxe"))
        {
            if (other.tag != "Player" && other.tag != "AttackBox" && other.tag != "Projectile")
            {

                projectileDamage = 6.0f;
                Collider[] hitColliders = Physics.OverlapSphere(other.transform.position, 1.5f);

                int i = 0;
                while (i < hitColliders.Length)
                {
                    if (hitColliders[i].tag == "Enemy")
                    {
                        hitColliders[i].gameObject.GetComponent<EnemyHealth>().TakeDamage(projectileDamage, false);
                        hitColliders[i].gameObject.GetComponent<AITest>().TakeDamage();
                    }
                    i++;
                }
                if (this != null)
                {
                    Destroy(gameObject);
                    GameObject VFX = Instantiate(explosionVFX, transform.position, transform.rotation);
                    Destroy(VFX, 1f);
                }

            }
        }
        //Destroy(gameObject);

    }
}
