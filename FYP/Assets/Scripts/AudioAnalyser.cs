using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnalyser : MonoBehaviour {

    const int FREQUENCY_BANDS = 1024;
    public float[] frequencyBandAmplitudes;
    float highestFrequency, frequencyBandRange, frequencyRangeMin, frequencyRangeMax;
    public float averageAmplitude;
    public bool beatDetected;

    // Use this for initialization
    void Start()
    {
        frequencyBandAmplitudes = new float[FREQUENCY_BANDS];
        highestFrequency = AudioSettings.outputSampleRate / 2;
        frequencyBandRange = highestFrequency / frequencyBandAmplitudes.Length;
        frequencyRangeMin = 60f;
        frequencyRangeMax = 250f;
        beatDetected = false;
    }

    // Update is called once per frame
    void Update()
    {
        AnalyseAudio();
    }

    void AnalyseAudio()
    {
        // Perform FFT analysis on the current window of playing audio on the AudioSource
        GetComponent<AudioSource>().GetSpectrumData(frequencyBandAmplitudes, 0, FFTWindow.BlackmanHarris);

        DetectBeat();
    }

    void DetectBeat()
    {
        float currentFrequency = 0f, amplitude = 0f, threshold = .07f;
        int numAmplitudes = 0;

        beatDetected = false;

        for(int i = 0; i < frequencyBandAmplitudes.Length; ++i)
        {
            // if current frequency is within given frequency range
            if(currentFrequency >= frequencyRangeMin && currentFrequency <= frequencyRangeMax)
            {
                amplitude += frequencyBandAmplitudes[i]; // accumulate amplitudes across the range of frequency bands
                ++numAmplitudes;
            }

            currentFrequency += frequencyBandRange; // accumulate total frequency so far
        }

        averageAmplitude = amplitude / numAmplitudes; // get average amplitude of frequency range 

        if(averageAmplitude > threshold)
        {
            beatDetected = true;
        }
    }
}
