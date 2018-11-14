using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualiser : MonoBehaviour {

    AudioAnalyser audioAnalyser;
    float[] frequencyBandAmplitudes;
    int numBands;
    public GameObject cube;
    List<GameObject> gameObjects;

	// Use this for initialization
	void Start () {
        audioAnalyser = GetComponent<AudioAnalyser>();
        numBands = 16;
        gameObjects = new List<GameObject>();

        frequencyBandAmplitudes = audioAnalyser.GetFrequencyBandAmplitudes();

        for(int i = 0; i < frequencyBandAmplitudes.Length; ++i)
        {
            gameObjects.Add(GameObject.Instantiate<GameObject>(cube, new Vector3((i - 30) * .6f, 0, 30), Quaternion.identity));
        }
    }
	
	// Update is called once per frame
	void Update () {
        frequencyBandAmplitudes = audioAnalyser.GetFrequencyBandAmplitudes();

        for(int i = 0; i < frequencyBandAmplitudes.Length; ++i)
        {
            gameObjects[i].transform.localScale = new Vector3(.5f, frequencyBandAmplitudes[i] * 200f, 1);
        }
    }
}
