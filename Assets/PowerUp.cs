using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect;
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }
    void Pickup(Collider player)
    {
        //Instantiate(pickupEffect, transform.position, transform.rotation);

        if (this.name.Contains("HealthPowerUp"))
        {
            player.GetComponent<PlayerHealth>().TriggerHealthPowerUp();
        }
        else if (this.name.Contains("StaminaPowerUp"))
        {
            player.GetComponent<character>().TriggerStaminaPowerUp();
        }
        //FindObjectOfType<AudioManager>().Play("powerup");
        Destroy(gameObject);
    }
}
