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
            player.GetComponent<PowerUpManager>().DecrementActivePowerUps();
        }
        else if (this.name.Contains("StaminaPowerUp"))
        {
            player.GetComponent<character>().TriggerStaminaPowerUp();
            player.GetComponent<PowerUpManager>().DecrementActivePowerUps();
        }
        else if (this.name.Contains("MagicAxePowerUp"))
        {
            player.GetComponent<character_animator>().TriggerMagicAxePowerUp();
            player.GetComponent<PowerUpManager>().DecrementActivePowerUps();
        }
        else if (this.name.Contains("SuperKickPowerUp"))
        {
            player.GetComponent<PlayerAttack>().SuperKickPowerUp();
            player.GetComponent<PowerUpManager>().DecrementActivePowerUps();
        }
          FindObjectOfType<AudioManager>().Play("powerup");

        Destroy(gameObject);
    }

}
