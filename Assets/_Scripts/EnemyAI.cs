using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [field: SerializeField]
    public Transform player;       // Reference to the player's position
    public float moveSpeed = 5f;   // Movement speed of the object
    private int damage = 1;        // Damage dealt to the player
    [SerializeField]
    private float hp = 3;        // Health of the object
    private float currenthp;
    private Rigidbody2D rb;        // Rigidbody2D component
    private float damageCooldown = 30f; // Cooldown for dealing damage
    private float nextDamageTime = 0f; // Cooldown for dealing damage
    private Vector2 moveDir;
    private Knockback knockback; // Reference to the Knockback component
    [SerializeField] private float knockbackForce = 15f; // Force applied during knockback

    private void Awake()
    {
        // Get the Knockback component
        knockback = GetComponent<Knockback>();
        rb = GetComponent<Rigidbody2D>();
        currenthp = hp;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }
    //void Start()
    //{
    //    // Get the Rigidbody2D component
    //    knockback = GetComponent<Knockback>();
    //    rb = GetComponent<Rigidbody2D>();
    //    currenthp = hp;
    //    GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
    //    if (playerObject != null)
    //    {
    //        player = playerObject.transform;
    //    }
    //}

    void Update()
    {
        // Check if player reference is set
        if (player != null && knockback.isKnockback == false)
        {
            MoveTo(player.position);
            rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void TakeDamage(float damage)
    {
        currenthp -= damage;
        knockback.GetKnockback(PlayerMovement.Instance.transform, knockbackForce);
        Debug.Log("Enemy Health: " + currenthp);
        if (currenthp <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        this.gameObject.SetActive(false);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        // Check if the object collided with the player
        if (collision.CompareTag("Player"))
        {
            // Get the PlayerHealth component from the player
            PlayerMovement playerHealth = collision.GetComponent<PlayerMovement>();
            // Check if the PlayerHealth component is found
            if (playerHealth != null && Time.time >= nextDamageTime)
            {
                // Deal damage to the player
                playerHealth.PlayerTakeDamage(damage);
                nextDamageTime = Time.time + damageCooldown;
            }
        }
    }
    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = (targetPosition - rb.position).normalized;
    }
}
