using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

    float angle, radius;
    Vector3 newPosition, startPosition;
    Quaternion startRotation;

	// Use this for initialization
	void Start () {
        angle = 0f;
        radius = .5f;
        newPosition = new Vector3();

        startPosition = transform.position;
        startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = startPosition;
        transform.rotation = startRotation;

        newPosition.x = (Mathf.Cos(angle) * radius) + startPosition.x;
        newPosition.y = (Mathf.Sin(angle) * radius) + startPosition.y;
        //newPosition.z = (Mathf.Cos(angle) * radius) + startPosition.z;
        newPosition.z = transform.position.z;
        angle += .05f;

        transform.position = newPosition;
    }
}
