using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour {

    public float speed;

	// Use this for initialization
	void Start () {
        speed = 10f;
	}
	
	// Update is called once per frame
	void Update () {
        //Camera camera = GetComponent<Camera>();

        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }

        if(Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(-transform.forward * speed * Time.deltaTime);
        }

        /*
		if(OVRInput.GetDown(OVRInput.Button.Any))
        {
            Debug.Log("Trigger Pressed");
        }
        */
    }
}
