using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_animator : MonoBehaviour
{
    Animator myAnimator;
    float elapsedTime;
    public PlayerHealth health;
    public float cur_health;
    bool isHurt = false;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        bool isWalkingPressed = CheckWalking();
        bool isAttackPressed = CheckAttack();
        bool isKilled = CheckKilled();
        bool isSprinting = CheckSprint();

        cur_health = health.cur_health;
        //Debug.Log("Test: ");


        myAnimator.SetBool("IsWalking", isWalkingPressed);
        myAnimator.SetBool("IsAttacking", isAttackPressed);
        myAnimator.SetBool("IsKilled", isKilled);
        myAnimator.SetBool("IsSprinting", isSprinting);
        //Debug.Log("Test: " + isAttackPressed);

       

    }

    bool CheckWalking()
    {
        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right")
           || Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            return true;
        else
            return false;


    }
    bool CheckAttack()
    {
        if (Input.GetMouseButtonDown(0))
            return true;
        else
            return false;
    }
    bool CheckKilled()
    {
        // Debug.Log("Test: " + cur_health);
        if (cur_health == -1)
            return true;
        else
            return false;
    }
    bool CheckSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !character.stamina_reset)
            return true;
        else
            return false;
    }
    public void TakeDamage()
    {
        Debug.Log("TEST");
        isHurt = true;
        myAnimator.SetBool("IsHurt", isHurt);
    }
}
