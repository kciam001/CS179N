using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_animator : MonoBehaviour
{
    Animator myAnimator;
    float elapsedTime;
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


        myAnimator.SetBool("IsWalking", isWalkingPressed);
        myAnimator.SetBool("IsAttacking", isAttackPressed);
        Debug.Log("Test: " + isAttackPressed);

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
}
