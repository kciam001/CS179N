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
        cur_health = 100.0f;
        SetCountText ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage){
        cur_health -= damage;
        SetCountText ();
        // Debug.Log(cur_health);
    }

    void SetCountText(){
        health_text.text = "Health: " + cur_health.ToString();
    }
}
