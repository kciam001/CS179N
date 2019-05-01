using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITest : MonoBehaviour
{
    public GameObject player;
    public float speed;
    static Animator anim;
   
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isIdle", true);
        anim.SetBool("isRunning", false);
        anim.SetBool("isAttacking", false);
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(player.transform.position, this.transform.position);
        if (dist < 15) //awake range
        {
            transform.LookAt(player.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * 0.01f);
            anim.SetBool("isIdle", false);
            if (dist > 5)
            {
                anim.SetBool("isRunning", true);
                anim.SetBool("isAttacking", false);
            }
            else { 
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