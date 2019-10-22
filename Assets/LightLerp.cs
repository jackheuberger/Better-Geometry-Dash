using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class LightLerp : MonoBehaviour
{
    public Color[] colors;
    private Color targetColor;
    private Light2D l2d;
    private Color changeColor;
    public float lerpTime = 60/100;
    private float colorStep;
    private int i = 0;

    // Stores the time through the song divided by the oscilation time
    private int previousDevision = 0;

    float prevTimeThroughSong = 0;
    AudioManager audioManager;


    // Start is called before the first frame update
    void Start()
    {
        l2d = GetComponent<Light2D>();
        audioManager = AudioManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        // How many beats through
        int currentDivision = Mathf.FloorToInt(audioManager.audioSource.time / lerpTime);

        //Lerps the color over an interval
        if (currentDivision == previousDevision)
        {
            changeColor = Color.Lerp(l2d.color, colors[i], colorStep);
            l2d.color = changeColor;
            colorStep += (audioManager.audioSource.time - prevTimeThroughSong)/lerpTime;
            prevTimeThroughSong = audioManager.audioSource.time;
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

            previousDevision = currentDivision;
        }
    }
}
