using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel : MonoBehaviour {

    AudioAnalyser analyser;
    public float speed = 10f;
    int elapsedTime;

	// Use this for initialization
	void Start () {
        elapsedTime = 0;
        GameObject audioAnalyser = GameObject.FindGameObjectWithTag("AudioAnalyser");
        analyser = audioAnalyser.GetComponent<AudioAnalyser>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.localScale = new Vector3(analyser.averageBassAmplitude * 5, analyser.averageBassAmplitude * 5, analyser.averageBassAmplitude * 5);

        if (elapsedTime >= 180)
        {
            if(gameObject != null)
            {
                Destroy(gameObject);
            }
        }

        ++elapsedTime;
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != null)
        {
            if (other.gameObject.tag == "Enemy")
            {
                other.gameObject.GetComponentInChildren<Health>().health -= 50;
            }
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Enemy")
    //    {
    //        Destroy(collision.gameObject);

    //        //Health[] health = collision.gameObject.GetComponentsInChildren<Health>();
    //        //health[0].health--;

    //        //Health health = collision.gameObject.GetComponent<Health>();
    //        //health.health -= 50;

    //        //collision.gameObject.GetComponent<Health>().health -= 50;
    //    }

    //    Debug.Log("Bullet collision");
    //    Destroy(gameObject);
    //}
}
