using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    public float speed = 1;
    int sprint_factor = 3;
    int stamina_factor = 5;
    float stamina = 0;
    // float timer = 0;
    float max_stamina = 10;
    public static bool stamina_reset = false;
    Vector3 playerMovement = Vector3.zero;

    public Text stamina_text;
    public Image stamina_bar;
    public Text special_text;
    public Image special_bar;
    private Color red = Color.red;
    private Color green = Color.green;
    private Color yellow = Color.yellow;
    private Color blue = Color.blue;

    float velocity = 5f;
    float turnSpeed = 10;
    Vector2 input;
    float angle;
    Quaternion targetRotation;
    Transform cam;
    bool staminaPowerUp = false;
    float timeLeft = 5f;

    character_animator char_anim;


    void Start()
    {
        cam = Camera.main.transform;
        char_anim = GetComponent<character_animator>();
        red.a = 0.3f;
        green.a = 0.3f;
    }
    // Update is called once per frame
    void Update()
    {
        if(staminaPowerUp)
        {
            timeLeft -= Time.deltaTime;
            stamina_text.text = "Unlimited Stamina " + timeLeft.ToString("f0") +"s";
            stamina_bar.fillAmount = 1;
            stamina_bar.color = green;
        }
        else if (stamina <= 0)
        {
            stamina_text.text = "Stamina";
            stamina_bar.fillAmount = 1;
            stamina_bar.color = green;
        }
        else if (stamina >= max_stamina)
        {
            stamina_text.text = "Stamina";
            stamina_bar.fillAmount = 0;
            stamina_bar.color = red;
        }
        else
        {
            stamina_text.text = "Stamina";
            stamina_bar.fillAmount = ((max_stamina - stamina) / max_stamina);
        }
        if (this.gameObject.GetComponent<PlayerHealth>().GetHealth() <= 0)
        {
            stamina_bar.fillAmount = 0;
            stamina_text.text = "";
        }
        GetInput();

        if (Mathf.Abs(input.x) < 1 && Mathf.Abs(input.y) < 1)
        {
            Move();
            return;
        }
        if (GetComponent<PlayerHealth>().GetHealth() > 0)
        {
            CalculateDirection();
            Rotate();
            Move();
        }
        SpecialPowerHUD();
    }

    void GetInput()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
    }

    void CalculateDirection()
    {
        angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle;
        angle += cam.eulerAngles.y;
    }

    void Rotate()
    {
        targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            transform.position += transform.forward * velocity * Time.deltaTime;
        }
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        //sprint
        if (Input.GetKey(KeyCode.LeftShift) && staminaPowerUp)
        {
            transform.position += transform.forward * velocity * sprint_factor * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftShift) && stamina < max_stamina && !stamina_reset && char_anim.isGrounded)
        {

            //playerMovement = new Vector3(x, 0f, y) * speed * sprint_factor * Time.deltaTime;
            transform.position += transform.forward * velocity * sprint_factor * Time.deltaTime;
            stamina += stamina_factor * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W) && !char_anim.isGrounded)
        {

            //playerMovement = new Vector3(x, 0f, y) * speed * sprint_factor * Time.deltaTime;
            transform.position += transform.forward * velocity * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A) && !char_anim.isGrounded)
        {

            //playerMovement = new Vector3(x, 0f, y) * speed * sprint_factor * Time.deltaTime;
            transform.position += transform.forward * velocity * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) && !char_anim.isGrounded)
        {

            //playerMovement = new Vector3(x, 0f, y) * speed * sprint_factor * Time.deltaTime;
            transform.position += transform.forward * velocity * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S) && !char_anim.isGrounded)
        {

            //playerMovement = new Vector3(x, 0f, y) * speed * sprint_factor * Time.deltaTime;
            transform.position += transform.forward * velocity * Time.deltaTime;
        }
        else if (stamina < max_stamina && stamina > 0 && !stamina_reset)
        {
            //playerMovement = new Vector3(x, 0f, y) * speed * Time.deltaTime;
            //transform.position += transform.forward * velocity * Time.deltaTime;
            stamina -= (stamina_factor * 0.25f) * Time.deltaTime;
        }
        else
        {
            //playerMovement = new Vector3(x, 0f, y) * speed * Time.deltaTime;
            //transform.position += transform.forward * velocity * Time.deltaTime;
            if (stamina >= max_stamina && !stamina_reset)
            {
                stamina_reset = true;
            }
            if (stamina > 0 && stamina_reset)
                stamina -= (stamina_factor * 0.5f) * Time.deltaTime;
            if (stamina <= 0)
                stamina_reset = false;

        }

        //transform.Translate(playerMovement, Space.Self);
    }

    public void TriggerStaminaPowerUp()
    {
        staminaPowerUp = true;
        Invoke("SetBackPowerUp", timeLeft);
    }
    void SetBackPowerUp()
    {
        staminaPowerUp = false;
        timeLeft = 5;
        stamina = 0;
    }
    void SpecialPowerHUD()
    {
        int specialPowerCharges = this.GetComponent<character_animator>().magicAxeCharges;
        if (specialPowerCharges != 0)
        {
            special_text.text = "Special Charges: " + specialPowerCharges.ToString();
            special_text.color = blue;
        }
        else
        {
            special_text.text = "";
        }

    }

}