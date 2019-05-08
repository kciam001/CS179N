using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    public float speed = 1;
    int sprint_factor = 3;
    int stamina_factor = 10;
    float stamina = 0;
    // float timer = 0;
    float max_stamina = 10;
    public static bool stamina_reset = false;
    Rect stamina_rect;
    Texture2D stamina_texture;
    Texture2D tired_texture;
    Vector3 playerMovement;

    public Text stamina_text;
    public Image stamina_bar;
    public Image stamina_BG;
    private Color red = Color.red;
    private Color green = Color.green;
    private Color none = Color.black;
    void Start()
    {
        red.a = 0.3f;
        green.a = 0.3f;
        none.a = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        if(stamina <= 0){
            stamina_text.text = "Stamina: 100";
            stamina_bar.fillAmount = 1;
            stamina_bar.color = green;
        }else if(stamina >= max_stamina){
            stamina_text.text = "Stamina: 0";
            stamina_bar.fillAmount = 0;
            stamina_bar.color = red;
        }else{
            stamina_text.text = "Stamina: " + (((max_stamina - stamina) / max_stamina) * 100).ToString();
            stamina_bar.fillAmount = ((max_stamina - stamina) / max_stamina);
        }
        if(this.gameObject.GetComponent<PlayerHealth>().GetHealth() <= 0){
            stamina_bar.fillAmount = 0;
            stamina_BG.color = none;
            stamina_text.text = "";
        }
        Move();
    }

    void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //sprint
        if (Input.GetKey(KeyCode.LeftShift) && stamina < max_stamina && !stamina_reset)
        {

            playerMovement = new Vector3(x, 0f, y) * speed * sprint_factor * Time.deltaTime;
            stamina += stamina_factor * Time.deltaTime;
        }
        else if (stamina < max_stamina && stamina > 0 && !stamina_reset)
        {
            playerMovement = new Vector3(x, 0f, y) * speed * Time.deltaTime;
            stamina -= (stamina_factor * 0.25f) * Time.deltaTime;
        }
        else
        {
            playerMovement = new Vector3(x, 0f, y) * speed * Time.deltaTime;
            if (stamina >= max_stamina && !stamina_reset)
            {
                stamina_reset = true;
            }
            if (stamina > 0 && stamina_reset)
                stamina -= (stamina_factor * 0.5f) * Time.deltaTime;
            if (stamina <= 0)
                stamina_reset = false;

        }
        transform.Translate(playerMovement, Space.Self);

    }
}