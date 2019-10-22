using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    // Horizontal
    public float hoSpeed = 10;
    // Vertical Speed
    public float verSpeed = 4;

    // Reference to rigidbody
    private Rigidbody2D rb;

    // Total amount of jumps the player is allowed
    public int totalJump = 2;
    // How many times the player has jumped since they touched the ground
    private int jumpCount = 0;

    // Stores y velocity
    private float yVel;

    // Stores the direction the character is facing (1 = right, -1 = left)
    private int direction = 1;

    //Number of music notes collected by player
    public int noteCount = 0;

    public TextMeshProUGUI noteText;
    // Start is called before the first frame update
    void Start()
    {
        // Gets rigidbody
        rb = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Sent when an incoming collider makes contact with this object's
    /// collider (2D physics only).
    /// </summary>
    /// <param name="other">The Collision2D data associated with this collision.</param>
    void OnCollisionEnter2D(Collision2D other)
    {
        // If touches object with tag Ground
        if(other.gameObject.CompareTag("Ground")){
            // Resets jumps
            jumpCount = 0;
            Debug.Log("On Ground");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Note"))
        {
            noteCount++;
            Destroy(other.gameObject);
            Debug.Log("Note!");
            updateText();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground")){
            Debug.Log("Off Ground");
        }
    }

    private void Update()
    {
        // The x input (arrows or WASD)
        float x = Input.GetAxisRaw("Horizontal");

        // If the direction is differenc than before
        if(direction != x && x!=0)
        {
            // Sets the direction to the new direction
            direction = (int)x;
            // Flips the player
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y);
        }

        if (Input.GetKeyDown(KeyCode.W) && (jumpCount < totalJump))
        {
            yVel = verSpeed;
            jumpCount++;
            Debug.Log("Jump");
        }
        else
            yVel = rb.velocity.y;

        // Sets the velocities on each axis
        rb.velocity = new Vector2(x * hoSpeed, yVel);
    }

    public void updateText()
    {
        noteText.text = noteCount.ToString();
    }
}
