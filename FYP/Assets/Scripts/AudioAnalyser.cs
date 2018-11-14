using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnalyser : MonoBehaviour {

    float[] frequencyBandAmplitudes;
    float highestFrequency, frequencyBandRange, minHertz, maxHertz;
    List<GameObject> gameObjects;
    public GameObject cube;
    public float averageAmplitude;
    int elapsedTime = 0;
    Clock clock;

    // Use this for initialization
    void Start()
    {
        clock = GetComponent<Clock>();
        frequencyBandAmplitudes = new float[1024];
        highestFrequency = AudioSettings.outputSampleRate / 2;
        frequencyBandRange = highestFrequency / frequencyBandAmplitudes.Length;
        minHertz = 60f;
        maxHertz = 250f;

        gameObjects = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<AudioSource>().GetSpectrumData(frequencyBandAmplitudes, 0, FFTWindow.BlackmanHarris);

        float currentFrequency = 0f;
        float amplitude = 0f;
        float threshold = .07f;
        int numAmplitudes = 0;

        for (int i = 0; i < frequencyBandAmplitudes.Length; ++i)
        {
            if (currentFrequency >= minHertz && currentFrequency <= maxHertz)
            {
                amplitude += frequencyBandAmplitudes[i];
                ++numAmplitudes;
            }

            currentFrequency += frequencyBandRange;
        }

        averageAmplitude = amplitude / numAmplitudes;

        if (averageAmplitude > threshold)
        {
            gameObjects.Add(GameObject.Instantiate<GameObject>(cube, new Vector3(Random.Range(-20, 20), Random.Range(-10, 10), 20), Quaternion.identity));
        }

        if (clock.GetElapsedTime() > 960)
        {
            clock.ResetTime();

            foreach (GameObject gameObject in gameObjects)
            {
                Destroy(gameObject);
            }
        }
    }
}
