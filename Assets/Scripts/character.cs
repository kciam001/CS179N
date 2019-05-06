using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    public float speed = 1;
    int sprint_factor = 3;
    int stamina_factor = 10;
    float stamina = 1;
    float timer = 0;
    float max_stamina = 10;
    public static bool stamina_reset = false;
    Rect stamina_rect;
    Texture2D stamina_texture;
    Texture2D tired_texture;
    Vector3 playerMovement;
    void Start()
    {
        stamina_rect = new Rect(Screen.width / 50, Screen.height * 9 / 12, Screen.width / 3, Screen.height / 50);
        stamina_texture = new Texture2D(1, 1);
        stamina_texture.SetPixel(0, 0, Color.green);
        tired_texture = new Texture2D(1, 1);
        tired_texture.SetPixel(0, 0, Color.red);
        stamina_texture.Apply();
        tired_texture.Apply();
    }
    // Update is called once per frame
    void Update()
    {
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
                stamina = 35;
                stamina_reset = true;
            }
            if (stamina > 0 && stamina_reset)
                stamina -= stamina_factor * Time.deltaTime;
            if (stamina <= 0)
                stamina_reset = false;

        }
        transform.Translate(playerMovement, Space.Self);
    }

    //stamina bar
    void OnGUI()
    {
        float ratio = (max_stamina - stamina) / max_stamina;
        float rect_width = ratio * Screen.width / 3;

        if (!stamina_reset)
        {
            stamina_rect.width = rect_width;
            GUI.DrawTexture(stamina_rect, stamina_texture);
        }
        else
        {
            stamina_rect.width = Screen.width / 3;
            GUI.DrawTexture(stamina_rect, tired_texture);
        }

    }
}