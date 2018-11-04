using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {
    private bool _alive;

    public float m_speed = 3.0f;
    public float m_castCircumference = 0.75f;
    public float m_obstacleRange = 5.0f;

    // Use this for initialization
    void Start () {
        _alive = true;
    }

	// Update is called once per frame
	void Update () {
        if (_alive)
        {
            transform.Translate(0f, 0f, m_speed * Time.deltaTime);

            // Detect objects
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, m_castCircumference, out hit))
            {
                if (hit.distance <= m_obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}
