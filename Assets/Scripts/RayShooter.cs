﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour {
    private Camera _camera;

	// Use this for initialization
	void Start () {
        _camera = GetComponent<Camera>();

        // Hide & lock mouse cursor at center of screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
	}

    // Inherited method of MonoBehavior
    void OnGUI(){
        int size = 12;
        int posX = _camera.pixelWidth / 2;
        int posY = _camera.pixelHeight / 2 - size / 2;

        GUI.Label(new Rect(posX, posY, size, size), "*");
    }
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)){
            Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight / 2, 0);
            Ray ray = _camera.ScreenPointToRay(point);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)){
                GameObject hitObject = hit.transform.gameObject;

                // Grab script component
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if(target != null ){
                    // Reactive Targets
                    target.ReactToHit();
                } else {
                    //  Non-Reactive - mark w/ a point
                    StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
	}

    private IEnumerator SphereIndicator(Vector3 pos){
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;

        yield return new WaitForSeconds(1);

        Destroy(sphere);
    }
}