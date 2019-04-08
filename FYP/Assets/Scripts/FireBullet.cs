using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {

    public GameObject bulletPrefab;
    public OVRInput.Button button;
    public bool isPlayer;
    bool canFire;
    int cooldownTime, timeLeftToFire;

	// Use this for initialization
	void Start () {
        canFire = true;
        cooldownTime = isPlayer ? 15 : 60;
        timeLeftToFire = cooldownTime;
	}
	
	// Update is called once per frame
	void Update () {
        if(canFire)
        {
            if(isPlayer)
            {
                if (OVRInput.Get(button))
                {
                    canFire = false;
                    GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, transform.position, transform.rotation);
                }
            }
            else
            {
                canFire = false;
                GameObject target = GameObject.FindGameObjectWithTag("Player");
                GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, transform.position, transform.rotation);
                bullet.transform.LookAt(target.transform);
                bullet.transform.Translate(0, 0, 2);
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
