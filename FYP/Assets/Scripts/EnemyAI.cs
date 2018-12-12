using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    Clock clock;
    public Vector3 velocity;

	// Use this for initialization
	void Start () {
        clock = GetComponent<Clock>();
        velocity = new Vector3(10, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if(clock.elapsedTime > 360f)
        {
            clock.ResetTime();

            velocity.x *= -1;
        }

        //transform.Translate(velocity * Time.deltaTime);
	}

    void OnCollisionEnter(Collision collision)
    {
        transform.Translate(0, 0, 10 * Time.deltaTime);
    }
}
