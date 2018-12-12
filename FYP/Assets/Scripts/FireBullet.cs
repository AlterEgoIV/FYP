using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {

    public GameObject bulletPrefab;
    public OVRInput.Button button;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(OVRInput.Get(button))
        {
            GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, transform.position, transform.rotation);
        }
	}
}
