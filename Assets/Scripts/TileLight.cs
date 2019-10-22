using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;

public class TileLight : MonoBehaviour
{
    private Light2D l2d;
    private BoxCollider2D bc2d;
    private SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        l2d = GetComponent<Light2D>();
        bc2d = GetComponentInParent<BoxCollider2D>();
        sr = GetComponentInParent<SpriteRenderer>();
        if(sr!=null)
            l2d.color = sr.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (bc2d.enabled)
        {
            l2d.enabled = true;
        }
        else
        {
            l2d.enabled = false;
        }
    }
}
