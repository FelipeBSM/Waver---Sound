using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour
{
    public float bias; // determina qual valor � uma batida
    public float timeStep; // o intervalo minimo entre cada batida
    public float timeToBeat; //tempo que dura a visualiza��o do espectro
    public float restSmoothTime; //velocidade de movimemtacao 


    private float m_previousAudioValue; 
    private float m_audioValue;
    private float m_timer;

    protected bool m_isBeat; //  estado de batida

    void Start()
    {
        
    }

    void Update()
    {
        OnUpdate();
    }

    public virtual void OnUpdate()
    {
        m_previousAudioValue = m_audioValue;
        m_audioValue = AudioSpectrum.spectrumValue;

        if (m_previousAudioValue > bias && m_audioValue <= bias)
        {
            if (m_timer > timeStep)
            {
                OnBeat();
            }
        }

        if (m_previousAudioValue <= bias && m_audioValue > bias)
        {
            if (m_timer > timeStep)
            {
                OnBeat();
            }
        }

        m_timer += Time.deltaTime;
    }

    public virtual void OnBeat()
    {
        m_timer = 0;
        m_isBeat = true;
    }
}
