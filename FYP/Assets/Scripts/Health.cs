using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    GameObject obj;
    public int health;
    int maxHealth;
    //Material material;
    float maxWidth;

	// Use this for initialization
	void Start () {
        //material = new Material(gameObject.GetComponent<Renderer>().material);
        //gameObject.GetComponent<Renderer>().material.color.a = .5f;

        obj = transform.parent.gameObject;
        //obj = GameObject.FindGameObjectWithTag("Enemy");
        maxHealth = health;
        maxWidth = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
        float width = Map(health, 0, maxHealth, 0, maxWidth);

        transform.localScale = new Vector3(width, transform.localScale.y, transform.localScale.z);

        //--health;

		if(health <= 0)
        {
            Destroy(this.gameObject);
            Destroy(obj);
        }
	}

    float Map(float value, float istart, float istop, float ostart, float ostop)
    {
        return ostart + (ostop - ostart) * ((value - istart) / (istop - istart));
    }
}
