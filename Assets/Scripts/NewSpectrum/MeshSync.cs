using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSync : MonoBehaviour
{
    private MeshGenerator meshGen;
    [SerializeField] private GetSpecAudio audioSpec;

    private void Start()
    {
        meshGen = GetComponent<MeshGenerator>();
    }
    private void Update()
    {
        if (audioSpec._audioSource.isPlaying)
            meshGen.MoveMesh(audioSpec.GetSamples());
        else
            meshGen.ResetMesh();
    }


}
