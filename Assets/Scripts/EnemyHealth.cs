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
    // Start is called before the first frame update
    void Start()
    {
        max_health = 15.0f;
        cur_health = 15.0f;
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
                    Destroy(enemy, 1f);
                    spawner.gameObject.GetComponent<SpawnEnemy>().UpdateCount();
                    player.gameObject.GetComponent<Score>().IncrementScore();
                }
            }
        }
    }
}
