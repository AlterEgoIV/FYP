using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public GameObject obj;
    public int health;
    int maxHealth;
    float maxWidth;

	// Use this for initialization
	void Start () {
        maxHealth = health;
        maxWidth = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        float width = Map(health, 0, maxHealth, 0, maxWidth);

        transform.localScale = new Vector3(width, transform.localScale.y, transform.localScale.z);

		if(health <= 0)
        {
            GameObject.FindGameObjectWithTag("EnemySpawner").GetComponent<EnemySpawner>().enemyCount--;

            if(this.gameObject != null)
            {
                Destroy(this.gameObject);
            }
            
            if(gameObject != null)
            {
                Destroy(obj);
            }
        }
	}

    float Map(float value, float istart, float istop, float ostart, float ostop)
    {
        return ostart + (ostop - ostart) * ((value - istart) / (istop - istart));
    }
}
