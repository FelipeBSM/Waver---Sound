using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeColor : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0, 1)] public float lerpTime; // time lerping

    public Color[] color; // color array
    public Image[] affectedImages;

    private int colorIndex;

    private float time;
    bool kill;


    void Start()
    {
        for (int i = 0; i < affectedImages.Length; i++)
        {
            affectedImages[i] = affectedImages[i].GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        LerpColor();
    }
   
    void LerpColor()
    {
        for (int i = 0; i < affectedImages.Length; i++)
        {
            affectedImages[i].color = Color.Lerp(affectedImages[i].color, color[colorIndex], lerpTime * Time.deltaTime);

            time = Mathf.Lerp(time, 1f, lerpTime * Time.deltaTime);
            if (time > 0.9f)
            {
                time = 0;
                colorIndex++;
                colorIndex = (colorIndex >= color.Length) ? 0 : colorIndex;
            }
        }
    }


}


