using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncMesh : AudioSyncer
{
    MeshGenerator meshGen;
    public Vector3 beatScale;
    public Vector3 restScale;
    // Start is called before the first frame update
    void Start()
    {
        meshGen = GetComponent<MeshGenerator>();
    }
   

    public override void OnBeat()
    {
        //Debug.Log("f1dsadsa");
        base.OnBeat();
        StopCoroutine("MoveToScale");
        StartCoroutine("MoveToScale", beatScale);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        if (m_isBeat)
        {
            return;
        }

        transform.localScale = Vector3.Lerp(transform.localScale, restScale, restSmoothTime * Time.deltaTime);
    }
}
