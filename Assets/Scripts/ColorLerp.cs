using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorLerp : MonoBehaviour
{
    public Color[] colors;
    private Color targetColor;
    private SpriteRenderer sr;
    private Color changeColor;
    private float lerpTime = 1;
    private float colorStep;
    private int i = 0;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Lerps the color over an interval
        if (lerpTime > colorStep)
        {
            changeColor = Color.Lerp(sr.color, colors[i], colorStep);
            sr.color = changeColor;
            colorStep += .025f;
        }
        else
        {
            //Increments color array
            colorStep = 0;
            if (i < (colors.Length - 1))
            { //Keep incrementing until i + 1 equals the Lengh
                i++;
            }
            else
            { //and then reset to zero
                i = 0;

            }


        }
    }
}
