using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(OVRInput.GetDown(OVRInput.Button.Any))
        {
            Debug.Log("Trigger Pressed");
        }
	}
}
