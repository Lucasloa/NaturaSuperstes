using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [field: SerializeField]
    public Transform player;       // Reference to the player's position
    public float moveSpeed = 5f;   // Movement speed of the object
    private Rigidbody2D rb;        // Rigidbody2D component

    void Start()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if player reference is set
        if (player != null)
        {
            // Calculate direction from the object to the player
            Vector2 direction = (player.position - transform.position).normalized;

            // Move the object towards the player by setting the velocity of the Rigidbody2D
            rb.linearVelocity = direction * moveSpeed;
        }
    }
}
