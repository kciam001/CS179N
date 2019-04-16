using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character_animator : MonoBehaviour
{
    Animator myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalkingPressed;
        if (Input.GetKey("up") || Input.GetKey("down") || Input.GetKey("left") || Input.GetKey("right")
           || Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
            isWalkingPressed = true;
        else
            isWalkingPressed = false;

        myAnimator.SetBool("IsWalking", isWalkingPressed);
        Debug.Log("Test: " + isWalkingPressed);
    }
}
