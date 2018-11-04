using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application;

public class MouseView : MonoBehaviour {
    public float m_speed = 3.0f;
    public float m_sensitivityHor = 9.0f;
    public float m_sensitivityVer = 9.0f;

    public RotationAxes m_axes = RotationAxes.MouseY;

    public float m_minVert = -45.0f;
    public float m_maxVert = 45.0f;

    private float _rotationX = 0f;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if(m_axes == RotationAxes.MouseX){
            // horizontal rotation here
            transform.Rotate(0f, Input.GetAxis("Mouse X") * m_sensitivityHor, 0f);
        }
        else if(m_axes == RotationAxes.MouseY){
            // vertical rotation here, vertical ("pitch") is along the x axis
            _rotationX -= Input.GetAxis("Mouse Y") * m_sensitivityVer;
            _rotationX = Mathf.Clamp(_rotationX, m_minVert, m_maxVert);

            // Preserve horizontal rotation, "yaw"
            float rotationY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else {
            // vertical rotation here, vertical ("pitch") is along the x axis
            float verDelta = Input.GetAxis("Mouse Y") * m_sensitivityHor;
            float rotationX = transform.localEulerAngles.x - verDelta;

            // Preserve horizontal rotation, "yaw"
            float horDelta = Input.GetAxis("Mouse X") * m_sensitivityVer;
            float rotationY = transform.localEulerAngles.y + horDelta;

            transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);
        }
	}
}
