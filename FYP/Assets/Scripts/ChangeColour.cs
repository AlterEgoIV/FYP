using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColour : MonoBehaviour
{
    public float rangeMin, rangeMax, cycleSpeed;
    public bool cycleColours;
    float colour;
    float counter;

    // Start is called before the first frame update
    void Start()
    {
        colour = 0f;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(cycleColours)
        {
            //colour = Map(colour, rangeMin, rangeMax, 0, 1);
            GetComponent<Renderer>().material.color = Color.HSVToRGB(Map(counter, rangeMin, rangeMax, 0, 1), 1, 1);
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.HSVToRGB(Map(transform.position.x, rangeMin, rangeMax, 0, 1), 1, 1);
        }

        counter += cycleSpeed;

        if(counter > rangeMax)
        {
            counter = rangeMin;
        }
    }

    float Map(float value, float istart, float istop, float ostart, float ostop)
    {
        return ostart + (ostop - ostart) * ((value - istart) / (istop - istart));
    }
}
