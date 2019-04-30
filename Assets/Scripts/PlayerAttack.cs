using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float damage;
    private float stayCount = 0.0f;
    public Collider coll;
    // Start is called before the first frame update
    void Start()
    {
        damage = 3.0f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider coll)
    {
        if (coll.tag == "Enemy")
        {
            if (stayCount > 0.5f)
            {
                //Debug.Log("damage");
                if (Input.GetMouseButtonDown(0))
                {
                    coll.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                    // Debug.Log("damage");
                }
                stayCount = 0.0f;
            }
            else
            {
                stayCount += Time.deltaTime;
            }
        }

    }
}
