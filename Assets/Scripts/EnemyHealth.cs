using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    private float max_health;
    public float cur_health;
    public GameObject spawner;
    public GameObject enemy;
    public GameObject player;
    public GameObject healthPowerUp;
    public GameObject staminaPowerUp;
    public GameObject magicAxePowerUp;
    public GameObject superKickPowerUp;
    public Image healthBar;
    string enemyName;
    // Start is called before the first frame update
    void Start()
    {
        enemyName = enemy.name;
        SetHealth();

    }

    // Update is called once per frame
    void Update()
    {
        if(cur_health <= 0){
            healthBar.fillAmount = 0;
        }else{
            healthBar.fillAmount = cur_health / max_health;
        }  
    }

    public void TakeDamage(float damage, bool outOfArena)
    {
       
        if(enemy != null){
            if (cur_health >= 0)
            {
                cur_health -= damage;
                if (cur_health <= 0)
                {
                    cur_health = -1;
                    enemy.gameObject.GetComponent<AITest>().TriggerDeath();
                    if(!outOfArena)
                        SpawnPowerUp();
                    Destroy(enemy, 2f);
                    OnDeath();

                  

                }
            }
        }
    }
    void SetHealth()
    {
        if (enemyName.Contains("Grunt"))
        {
            max_health = 25.0f;
            cur_health = 25.0f;
        }
        else if (enemyName.Contains("TrollGiant"))
        {
            max_health = 40.0f;
            cur_health = 40.0f;
        }
        else if (enemyName.Contains("Lich"))
        {
            max_health = 7.0f;
            cur_health = 7.0f;
        }
        else if (enemyName.Contains("Skeleton"))
        {
            max_health = 10.0f;
            cur_health = 10.0f;
        }
    }
    void SpawnPowerUp()
    {
        int powerUp = Random.Range(0, 6);
        Vector3 position = transform.position + new Vector3(0, -2f, 0);
        if (powerUp == 0)
        {
            if(healthPowerUp != null)
                Instantiate(healthPowerUp, position, transform.rotation);
        }
        else if (powerUp == 1)
        {
            if(staminaPowerUp != null)
                Instantiate(staminaPowerUp, position, transform.rotation);
        }
        else if (powerUp == 2)
        {
            if(magicAxePowerUp != null)
                Instantiate(magicAxePowerUp, position, transform.rotation);

        }
        else if (powerUp == 3)
        {
            if (superKickPowerUp != null)
                Instantiate(superKickPowerUp, position, transform.rotation);

        }


    }
    public void OnDeath()
    {

        int points = 0;

        if (enemyName.Contains("Grunt"))
        {
            points = 2;
        }
        else if (enemyName.Contains("TrollGiant"))
        {
            points = 4;
        }
        else if (enemyName.Contains("Lich"))
        {
            points = 3;
        }
        else if (enemyName.Contains("Skeleton"))
        {
            points = 1;
        }
      
        spawner.gameObject.GetComponent<SpawnEnemy>().UpdateCount();
        player.gameObject.GetComponent<Score>().IncrementScore(points);

    }
}
