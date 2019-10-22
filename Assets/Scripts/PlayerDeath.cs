using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerDeath : MonoBehaviour
{
    // The minimum y value before death
    public float minimumYPosition = -70f;

    // The last checkpoint the player has reached
    public Transform checkpoint;

    private Rigidbody2D rb;

    public int deathCount = 0;
    public TextMeshProUGUI deathText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the player falls too far dowm
        if (transform.position.y <= minimumYPosition)
            KillPlayer();
    }


    public void KillPlayer()
    {

        // If there is a checkpoint
        if(checkpoint != null)
        {
            // Resets velocity
            rb.velocity = new Vector2(rb.velocity.x, 0);
            // Move the player to that checkpoint
            transform.position = checkpoint.position;
        }
        deathCount++;
        deathText.text = deathCount.ToString();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If the collision is a checkpoint
        if(collision.tag == "Checkpoint")
        {
            // Set it as the new checkpoint
            checkpoint = collision.transform;
        }
    }
}
