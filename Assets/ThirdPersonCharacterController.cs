using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCharacterController : MonoBehaviour
{

    public float speed = 1;
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(x, 0f, y) * speed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }
}
