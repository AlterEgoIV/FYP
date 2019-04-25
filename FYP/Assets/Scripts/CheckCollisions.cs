using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    GameObject healthbar;

    // Start is called before the first frame update
    void Start()
    {
        healthbar = GameObject.FindGameObjectWithTag("EnemyHealthbar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            healthbar.GetComponent<Health>().health -= 50;
        }
    }
}
