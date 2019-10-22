using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTile : MonoBehaviour
{

    // The tempo the platforms should change at
    public float tempo = 50f;
    // Whether this platform is offset from the beat or not
    public bool offset;

    // How that tempo converts to seconds
    private float oscillationTime;

    private SpriteRenderer spriteRenderer;
    private Collider2D boxCollider;

    AudioManager audioManager;

    // Stores the time through the song divided by the oscilation time
    private int previousDevision = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Defines the seconds to wait
        oscillationTime = (60 / tempo);

        // Gets the renderer
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Gets the collider
        boxCollider = GetComponent<Collider2D>();

        audioManager = AudioManager.Instance;

        // Offsets this block
        if (offset)
            ToggleState();
    }

    // Update is called once per frame
    void Update()
    {
        // If nothing is playing, don't do anything
        if (!audioManager.audioSource.isPlaying)
            return;

        // Defines the seconds to wait
        oscillationTime = (60 / tempo);

        // How many beats through
        int currentDivision = Mathf.FloorToInt(audioManager.audioSource.time / oscillationTime);

        if(currentDivision != previousDevision)
        {
            ToggleState();
            previousDevision = currentDivision;
        }

    }


    public void ToggleState()
    {
        // Toggles the collider
        boxCollider.enabled = !boxCollider.enabled;
        // Decides the opacity of the box
        float opacity = boxCollider.enabled ? 1 : 0.4f;

        // Sets the opacity
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, opacity);

        
    }
}
