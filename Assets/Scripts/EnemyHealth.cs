using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float cur_health;
    public GameObject enemy;
    public GameObject spawner;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        cur_health = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float damage)
    {
        if (cur_health >= 0)
        {
            cur_health -= damage;
            if (cur_health <= 0)
            {
                cur_health = -1;
                // INSERT DEATH ANIMATION HERE
                Destroy(enemy);
                spawner.gameObject.GetComponent<SpawnEnemy>().UpdateCount();
                player.gameObject.GetComponent<Score>().IncrementScore();
            }
        }
    }
}
