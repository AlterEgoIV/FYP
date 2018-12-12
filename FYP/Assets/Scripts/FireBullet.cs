using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {

    public GameObject bulletPrefab;
    public OVRInput.Button button;
    bool canFire;
    int cooldownTime, timeLeftToFire;

	// Use this for initialization
	void Start () {
        canFire = true;
        cooldownTime = 15;
        timeLeftToFire = cooldownTime;
	}
	
	// Update is called once per frame
	void Update () {
        if(canFire)
        {
            if (OVRInput.Get(button))
            {
                canFire = false;
                GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, transform.position, transform.rotation);
            }
        }

        if(!canFire)
        {
            --timeLeftToFire;

            if(timeLeftToFire == 0)
            {
                canFire = true;
                timeLeftToFire = cooldownTime;
            }
        }
	}
}
