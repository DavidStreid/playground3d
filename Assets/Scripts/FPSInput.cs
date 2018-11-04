using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    private CharacterController _charController;

    public float m_speed = 6.0f;
    public float m_gravity = -9.8f;


	// Use this for initialization
	void Start () {
        _charController = GetComponent<CharacterController>();	
	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * m_speed * Time.deltaTime;
        float deltaZ = Input.GetAxis("Vertical") * m_speed * Time.deltaTime;

        Vector3 movement = new Vector3(deltaX, m_gravity, deltaZ);
        movement = Vector3.ClampMagnitude(movement, m_speed);

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        _charController.Move(movement);

        /*
        Vector3 movement = new Vector3(deltaX, 0, deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);

        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);

        transform.Translate(deltaX, 0, deltaZ);
        */
    }
}
