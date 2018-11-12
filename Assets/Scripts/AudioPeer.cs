using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioPeer : MonoBehaviour {
    AudioSource _audioSource;
    public static float[] _samples = new float[512];
    public static float[] _freqBand = new float[8];
    public static float[] _bandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];

    public static AudioPeer Instance;

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start () {
        _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
    }

    void GetSpectrumAudioSource()
    {
        // FFTWindow.etc: Different leakage filters of spectrum data
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer()
    {
        for (int i = 0; i < 8; i++)
        {
            if (_freqBand[i] > _bandBuffer[i]) {
                _bandBuffer[i] = _freqBand[i];
                _bufferDecrease[i] = 0.005f;
            }
            if (_freqBand[i] < _bandBuffer[i]) {
                _bandBuffer[i] -= _bufferDecrease[i];
                _bufferDecrease[i] *= 1.2f; // Increase buffer fallout by 20%
            }
        }
    }

    void MakeFrequencyBands()
    {
        /*
         * 22050 / 512 = 43 hertz per sample
         * 
         * 20 - 60 hertz
         * 60 - 250
         * 250 - 500
         * 500 - 2000
         * 2000 - 4000
         * 4000 - 6000
         * 6000 - 20000
         * 
         * 0 - 2 = 86 hertz
         * 1 - 4 = 172          : 87 - 258
         * 2 - 8 = 344          : 259 - 602
         * 3 - 16 = 688         : 603 - 1290
         * 4 - 32 = 1266        : 1291 - 2666
         * 5 - 64 = 2753        : 2667 - 5418
         * 6 - 128 = 5504       : 5419 - 10922
         * 7 - 256 = 11008      : 10923 - 21920
         */

        int count = 0;
        for (int i = 0; i < 8; i++)
        {
            float avg = 0;
            int sampCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7) { sampCount += 2; }
            // Setting frequency bandwidths
            for (int j = 0; j < sampCount; j++)
            {
                avg += _samples[count] * (count + 1);
                count++;
            }

            avg /= count;

            _freqBand[i] = avg * 10;
        }
    }
}
