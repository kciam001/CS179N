using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float cur_health;
    public Text health_text;
    // Start is called before the first frame update
    void Start()
    {
        cur_health = 20.0f;
        SetCountText ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage){
        if (cur_health >= 0)
        {
            cur_health -= damage;
            if (cur_health <= 0)
            {
                cur_health = -1;
            }
        }
        SetCountText();
    }

    public float GetHealth(){
        return cur_health;
    }

    void SetCountText()
    {
        if (cur_health > 0)
        {
            health_text.text = "Health: " + cur_health.ToString();
        }
        else
        {
            health_text.text = "GameOver";
        }
    }
}
