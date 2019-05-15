using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_animator : MonoBehaviour
{
    public Animator myAnimator;
    float elapsedTime;
    public PlayerHealth health;
    public float cur_health;
    bool isHurt = false;
    Rigidbody rb;
    public CapsuleCollider col;
    public Vector3 jump;
    public float jumpForce = 7.0f;
    public bool isGrounded;
    bool isWalkingPressed;
    bool isAttackPressed;
    bool isKilled;
    bool isSprinting;
    public bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
        jump = new Vector3(0f, 2f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

        isWalkingPressed = CheckWalking();
        isAttackPressed = CheckAttack();
        isKilled = CheckKilled();
        isSprinting = CheckSprint();
        isJumping = CheckJump();

        cur_health = health.cur_health;
        //Debug.Log("Test: ");

        //Debug.Log(isAttackPressed);
        myAnimator.SetBool("IsWalking", isWalkingPressed);
        myAnimator.SetBool("IsAttacking", isAttackPressed);
        myAnimator.SetBool("IsKilled", isKilled);
        myAnimator.SetBool("IsSprinting", isSprinting);
        //myAnimator.SetBool("IsJumping", isJumping);
        //Debug.Log("Test: " + isAttackPressed);



    }

    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
        isJumping = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        isJumping = true;
        isGrounded = false;
    }


    bool CheckJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 200f, ForceMode.Impulse);
            isWalkingPressed = false;
            return true;
        }
        return false;
    }

    bool CheckWalking()
    {
        if ((Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right")
           || Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d")) && (isGrounded))
            return true;
        else
            return false;


    }
    public bool CheckAttack()
    {
        if (Input.GetMouseButtonDown(0))
        {

            return true;
        }
        else
            return false;
    }
    bool CheckKilled()
    {
        // Debug.Log("Test: " + cur_health);
        if (cur_health <= -1)
            return true;
        else
            return false;
    }
    bool CheckSprint()
    {
        if ((Input.GetKey(KeyCode.LeftShift) && !character.stamina_reset) && (isGrounded))
            return true;
        else
            return false;
    }
    public void TakeDamage()
    {
        isHurt = true;
        myAnimator.SetBool("IsHurt", isHurt);
    }
}
