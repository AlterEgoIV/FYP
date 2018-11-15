using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualiser : MonoBehaviour {

    AudioAnalyser audioAnalyser;
    float[] frequencyBandAmplitudes;
    int numBands;
    public GameObject cube;
    List<GameObject> gameObjects;
    List<GameObject> beats;
    Clock clock;

	// Use this for initialization
	void Start () {
        audioAnalyser = GetComponent<AudioAnalyser>();
        clock = GetComponent<Clock>();
        numBands = 16;
        gameObjects = new List<GameObject>();
        beats = new List<GameObject>();

        frequencyBandAmplitudes = audioAnalyser.frequencyBandAmplitudes;

        for(int i = 0; i < frequencyBandAmplitudes.Length; ++i)
        {
            gameObjects.Add(GameObject.Instantiate<GameObject>(cube, new Vector3((i - 30) * .6f, 0, 30), Quaternion.identity));
        }
    }
	
	// Update is called once per frame
	void Update () {
        frequencyBandAmplitudes = audioAnalyser.frequencyBandAmplitudes;

        for(int i = 0; i < frequencyBandAmplitudes.Length; ++i)
        {
            gameObjects[i].transform.localScale = new Vector3(.5f, frequencyBandAmplitudes[i] * 200f, 1);
        }

        if(audioAnalyser.beatDetected)
        {
            beats.Add(GameObject.Instantiate<GameObject>(cube, new Vector3(Random.Range(-60, -40), Random.Range(0, 10), 20), Quaternion.identity));
        }

        if(clock.elapsedTime > 720)
        {
            clock.ResetTime();

            for(int i = 0; i < beats.Count; ++i)
            {
                Destroy(beats[i]);
            }
        }
    }
}
