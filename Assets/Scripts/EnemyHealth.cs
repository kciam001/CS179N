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

    public void TakeDamage(float damage)
    {
        if(enemy != null){
            if (cur_health >= 0)
            {
                cur_health -= damage;
                if (cur_health <= 0)
                {
                    cur_health = -1;
                    enemy.gameObject.GetComponent<AITest>().TriggerDeath();
                    Destroy(enemy, 2f);
                    spawner.gameObject.GetComponent<SpawnEnemy>().UpdateCount();
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
                    player.gameObject.GetComponent<Score>().IncrementScore(points);
                }
            }
        }
    }
    void SetHealth()
    {
        if (enemyName.Contains("Grunt"))
        {
            max_health = 15.0f;
            cur_health = 15.0f;
        }
        else if (enemyName.Contains("TrollGiant"))
        {
            max_health = 30.0f;
            cur_health = 30.0f;
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
}
