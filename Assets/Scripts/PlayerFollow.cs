using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{

    // The player
    public Transform target;
    // Controlls the smoothing effect
    public float smoothTime = 0.3f;
    // To feed into SmoothDamp function
    private Vector3 velocity;
    // The amount the camera is offset from the player
    public Vector3 cameraOffset;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // Defines the position to move towards
        Vector3 targetPos = target.position + cameraOffset;

        // Smoothly moves camera towards target
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
        
    }
}
