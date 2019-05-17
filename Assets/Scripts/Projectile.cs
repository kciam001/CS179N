using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    private float projectileDamage = 7.0f;
    void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(projectileDamage);
            other.gameObject.GetComponent<character_animator>().TakeDamage();
            if(this != null)
            {
                Destroy(gameObject);
            }
        }
        //Destroy(gameObject);
        //Instantiate(explosionVFX, transform.position, transform.rotation);
    }
}
