using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {

    public GameObject bulletPrefab;
    GameObject analyser;
    public OVRInput.Button button;
    public bool isPlayer;
    bool canFire;
    int cooldownTime, timeLeftToFire;

	// Use this for initialization
	void Start () {
        canFire = true;
        cooldownTime = isPlayer ? 5 : 60;
        timeLeftToFire = cooldownTime;
        analyser = GameObject.FindGameObjectWithTag("AudioAnalyser");
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
                    bullet.GetComponent<Travel>().speed = 100f;
                }
            }
            else
            {
                if(analyser.GetComponent<AudioAnalyser>().beatDetected)
                {
                    GameObject target = GameObject.FindGameObjectWithTag("Player");
                    GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, transform.position, transform.rotation);
                    bullet.transform.LookAt(target.transform);
                    bullet.transform.Translate(0, 0, 2);
                }

                //canFire = false;
                
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
