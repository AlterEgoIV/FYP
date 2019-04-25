using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour {

    public GameObject bulletPrefab;
    GameObject target;
    Vector3 targetPosition;
    AudioAnalyser analyser;
    public OVRInput.Button button;
    public bool isPlayer;
    bool canFire;
    int cooldownTime, timeLeftToFire;

	// Use this for initialization
	void Start () {
        canFire = true;
        cooldownTime = isPlayer ? 5 : 60;
        timeLeftToFire = cooldownTime;
        GameObject audioAnalyser = GameObject.FindGameObjectWithTag("AudioAnalyser");
        analyser = audioAnalyser.GetComponent<AudioAnalyser>();
        target = GameObject.FindGameObjectWithTag("Player");
        targetPosition = new Vector3(target.transform.position.x, target.transform.position.y + 1f, target.transform.position.z);

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
                    bullet.GetComponent<Travel>().speed = 30f;
                    bullet.GetComponent<Travel>().isPlayerBullet = true;
                }
            }
            else
            {
                if(analyser.beatDetected)
                {
                    GameObject bullet = GameObject.Instantiate<GameObject>(bulletPrefab, transform.position, transform.rotation);
                    bullet.transform.LookAt(targetPosition);
                    bullet.transform.Translate(0, 0, 2);
                    bullet.GetComponent<Travel>().speed = 5;
                    bullet.GetComponent<Travel>().isPlayerBullet = false;
                }
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
