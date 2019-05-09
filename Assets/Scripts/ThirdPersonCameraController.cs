using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    /*
    public float CameraMoveSpeed = 120.0f;
    public Transform target;
    public Transform player;
    Vector3 FollowPosition;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    public float smoothX;
    public float smoothY;
    private float rotY = 0.0f;
    private float rotX = 0.0f;

    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputZ = Input.GetAxis("RightStickVertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);

        transform.rotation = localRotation;


    }

    void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {

        //move towards the game object that is the target
        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        player.rotation = Quaternion.Euler(0, rotY, 0);

    }
    */
    [Header("Drag the Object you want to follow here")]
    [Space(5)]
    [Tooltip("The best way to use this is to create an empty gameobject and parent it to your players hip/pelvis bone.")]
    public GameObject CameraFollowObj = GameObject.Find("target");

    [Header("Adjust these values to how you want the camera to rotate")]
    [Space(5)]
    public float CameraMoveSpeed = 120.0f;
    public float clampAngle = 80.0f;
    public float inputSensitivity = 150.0f;

    Vector3 FollowPOS;
    GameObject CameraObj;
    GameObject PlayerObj;
    float camDistanceXToPlayer;
    float camDistanceYToPlayer;
    float camDistanceZToPlayer;
    float mouseX;
    float mouseY;
    float finalInputX;
    float finalInputZ;
    float smoothX;
    float smoothY;
    float rotY = 0.0f;
    float rotX = 0.0f;
    float inputX;
    float inputZ;
    GameObject player;



    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        // We setup the rotation of the sticks here
        inputX = Input.GetAxis("RightStickHorizontal");
        inputZ = Input.GetAxis("RightStickVertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        rotY += finalInputX * inputSensitivity * Time.deltaTime;
        rotX += finalInputZ * inputSensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;



    }

    void LateUpdate()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        // set the target object to follow
        Transform target = CameraFollowObj.transform;

        //move towards the game object that is the target
        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
