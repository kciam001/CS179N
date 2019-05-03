using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour {
    public LayerMask movementMask;  
    Camera cam;
    PlayerMovement move;

	// Use this for initialization
	void Start () {
        cam = Camera.main;
        move = GetComponent<PlayerMovement>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                move.MoveToPoint(hit.point);
            }
        }
	}
}
