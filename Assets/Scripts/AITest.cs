using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITest : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public Animator anim;
    bool isHurt = false;
    bool playerDead = false;
    public bool isPaused;
    string enemyName;
    public PauseMenu Pause;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isIdle", true);
        anim.SetBool("isRunning", false);
        anim.SetBool("isAttacking", false);
        enemyName = this.name;
        SetSpeed();

    }

    // Update is called once per frame
    void Update()
    {
        isPaused = Pause.isPaused;
        if (!isPaused)
        {
            playerDead = player.GetComponent<PlayerHealth>().cur_health <= 0;
            float dist = Vector3.Distance(player.transform.position, this.transform.position);

            if (playerDead)
            {
                anim.SetBool("isIdle", true);
                anim.SetBool("isRunning", false);
                anim.SetBool("isAttacking", false);
            }
            else if (this.GetComponent<EnemyHealth>().cur_health >= 0)
            {
                if (dist < 100) //awake range
                {
                    transform.LookAt(player.transform.position);

                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * 0.01f);

                    anim.SetBool("isIdle", false);
                    if (enemyName.Contains("Lich"))
                    {
                        if (dist > 20)
                        {
                            anim.SetBool("isRunning", true);
                            anim.SetBool("isAttacking", false);

                        }
                        else
                        {

                            anim.SetBool("isAttacking", true);
                            anim.SetBool("isRunning", false);
                        }

                    }
                    else if (dist > 5)
                    {
                        anim.SetBool("isRunning", true);
                        anim.SetBool("isAttacking", false);
                    }
                    else
                    {
                        anim.SetBool("isAttacking", true);
                        anim.SetBool("isRunning", false);
                    }

                }
                else //idle range
                {
                    anim.SetBool("isIdle", true);
                    anim.SetBool("isRunning", false);
                    //anim.SetBool("isAttacking", false);
                }
            }
        }
    }
    public void TriggerDeath()
    {
        anim.SetBool("isDead", true);
    }
    public void TakeDamage()
    {
        isHurt = true;
        anim.SetBool("IsHurt", isHurt);

    }
    void SetSpeed()
    {
        if (enemyName.Contains("Grunt"))
        {
            speed = 16.0f;
        }
        else if (enemyName.Contains("TrollGiant"))
        {
            speed = 12.0f;
        }
        else if(enemyName.Contains("Lich"))
        {
            speed = 10.0f;
        }
        else if (enemyName.Contains("Skeleton"))
        {
            speed = 20.0f;
        }
    }
}