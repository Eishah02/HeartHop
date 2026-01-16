using UnityEngine;
using UnityEngine.SceneManagement; // Needed for restarting the game

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    [Header("Debug Info")]
    public int floorsTouching = 0; 
    public bool isGrounded = false;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

\        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If we touch a Spike = Restart Level
        if (collision.gameObject.name.Contains("Spike"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        // If we touch a Floor = We are grounded
        else 
        {
            floorsTouching = floorsTouching + 1;
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.name.Contains("Spike"))
        {
            floorsTouching = floorsTouching - 1;
            
            if (floorsTouching <= 0)
            {
                isGrounded = false;
                floorsTouching = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If we touch a Heart = Collect it
        if (collision.gameObject.name.Contains("Heart"))
        {
            Destroy(collision.gameObject);
        }

        // If we touch the Flag = WIN!
        if (collision.gameObject.name.Contains("Flag"))
        {
            Debug.Log("YOU WIN! CONGRATS!");
            Destroy(collision.gameObject);
        }
    }
}