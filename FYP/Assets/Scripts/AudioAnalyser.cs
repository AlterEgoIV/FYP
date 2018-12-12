using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAnalyser : MonoBehaviour {

    const int FREQUENCY_BANDS = 1024;
    public float[] spectrum, curSpectrum, prevSpectrum;
    float highestFrequency, frequencyBandRange, frequencyRangeMin, frequencyRangeMax;
    public float averageAmplitude;
    public bool beatDetected;

    // Use this for initialization
    void Start()
    {
        spectrum = new float[FREQUENCY_BANDS];
        curSpectrum = new float[FREQUENCY_BANDS];
        prevSpectrum = new float[FREQUENCY_BANDS];
        highestFrequency = AudioSettings.outputSampleRate / 2;
        frequencyBandRange = highestFrequency / curSpectrum.Length;
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
        GetComponent<AudioSource>().GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
        SetCurrentSpectrum(spectrum);

        DetectBeat();
    }

    void SetCurrentSpectrum(float[] spectrum)
    {
        curSpectrum.CopyTo(prevSpectrum, 0);
        spectrum.CopyTo(curSpectrum, 0);
    }

    /*void DetectBeat()
    {
        float changeInAmplitude = 0f;
        beatDetected = false;

        for(int i = 0; i < FREQUENCY_BANDS; ++i)
        {
            if(curSpectrum[i] > prevSpectrum[i])
            {
                changeInAmplitude += curSpectrum[i] - prevSpectrum[i];
            }
        }
    }*/

    void DetectBeat()
    {
        float currentFrequency = 0f, amplitude = 0f, threshold = .07f;
        int numAmplitudes = 0;

        beatDetected = false;

        for(int i = 0; i < curSpectrum.Length; ++i)
        {
            // if current frequency is within given frequency range
            if(currentFrequency >= frequencyRangeMin && currentFrequency <= frequencyRangeMax)
            {
                amplitude += curSpectrum[i]; // accumulate amplitudes across the range of frequency bands
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
