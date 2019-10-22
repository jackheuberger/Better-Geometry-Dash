using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class MusicLight : MonoBehaviour
{
    [SerializeField]
    private Light2D light;
    [SerializeField]
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
        sr = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        light.color = sr.color;
    }
}