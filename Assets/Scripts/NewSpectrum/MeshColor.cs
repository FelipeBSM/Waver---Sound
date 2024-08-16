using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshColor : MonoBehaviour
{
    private float lerpTime = 1f;
    public bool change = false;
    public Color[] color;

    private MeshRenderer meshRender;
    private float time;
    private int colorIndex;

    void Start()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (change)
        {
            changeColor();
        }
    }

    void changeColor()
    {
        meshRender.material.SetColor("_WireColor", Color.Lerp(meshRender.material.GetColor("_WireColor"), color[colorIndex], lerpTime * Time.deltaTime));
        time = Mathf.Lerp(time, 1f, lerpTime * Time.deltaTime);
        if (time > 0.9f)
        {
            time = 0;
            colorIndex++;
            colorIndex = (colorIndex >= color.Length) ? 0 : colorIndex;
        }
    }

    public void resetColor()
    {
        meshRender.material.SetColor("_WireColor", Color.white);
    }
}
