using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [field: SerializeField]
    public Transform player;       // Reference to the player's position
    public float moveSpeed = 5f;   // Movement speed of the object
    private int damage = 1;        // Damage dealt to the player
    private float hp = 3;        // Health of the object
    private float currenthp;
    private Rigidbody2D rb;        // Rigidbody2D component
    private float damageCooldown = 30f; // Cooldown for dealing damage
    private float nextDamageTime = 0f; // Cooldown for dealing damage
    private Vector2 moveDir;
    [SerializeField] private GameObject currencyPrefab; // Reference to the currency prefab


    void Awake()
    {
        // Get the Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
        currenthp = hp;
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if(playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        // Check if player reference is set
        if (player != null)
        {
            MoveTo(player.position);
            rb.MovePosition(rb.position + moveDir * moveSpeed * Time.fixedDeltaTime);
        }
    }

    public void TakeDamage(float damage)
    {
        currenthp -= damage;
        Debug.Log("Enemy Health: " + currenthp);
        if (currenthp <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        this.gameObject.SetActive(false);
        Instantiate(currencyPrefab, transform.position, Quaternion.identity);
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
                playerHealth.TakeDamage(damage);
                nextDamageTime = Time.time + damageCooldown;
            }
        }
    }
    public void MoveTo(Vector2 targetPosition)
    {
        moveDir = (targetPosition - rb.position).normalized;
    }
}
