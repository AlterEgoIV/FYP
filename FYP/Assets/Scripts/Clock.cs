using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float elapsedTime;

    // Use this for initialization
    void Start()
    {
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        ++elapsedTime;
    }

    public void ResetTime()
    {
        elapsedTime = 0f;
    }
}
