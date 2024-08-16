using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSpecAudio : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] public AudioSource _audioSource;
    
    private float[] samples = new float[512];
   

    private void Update()
    {
        _audioSource.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    
    }

    

    public float[] GetSamples()
    {
        return this.samples;
    }
  
}
