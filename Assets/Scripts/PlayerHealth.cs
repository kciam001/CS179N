
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    private float max_health;
    public float cur_health;
    public TextMeshProUGUI health_text;
    public Image health_bar;
    private Color green = Color.green;
    private Color yellow = Color.yellow;
    private Color red = Color.red;
    GameObject scoreBoard;
    public bool resetBoard = false;
 
    // Start is called before the first frame update
    void Start()
    {
        max_health = 100.0f;
        cur_health = max_health;
        SetCountText ();
        red.a = 0.3f;
        yellow.a = 0.3f;
        green.a = 0.3f;
        scoreBoard = GameObject.Find("ScoreBoard");
        scoreBoard.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("r"))
        {
            resetBoard = true;
        }

        health_bar.color = red;
        health_bar.fillAmount = cur_health / max_health;
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
            health_text.text = "Health";
        }
        else
        {
            health_text.text = "GameOver";
            Invoke("ShowScoreBoard", 4);

        }
    }
    void ShowScoreBoard()
    {
        scoreBoard.gameObject.SetActive(true);
    }
    public void TriggerHealthPowerUp()
    {
        if (cur_health <= 80 && cur_health > 0)
            cur_health += 20;
        else if (cur_health > 80)
            cur_health = 100;
    }
}
