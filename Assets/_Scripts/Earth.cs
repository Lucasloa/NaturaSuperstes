using UnityEngine;

public class Earth : Element
{
    [SerializeField] public float damage;
    [SerializeField] private float levelBonus;
    [SerializeField] private GameObject projectilePrefab; // Reference to the projectile prefab
    [SerializeField] private Transform earthspawn;
    [SerializeField] private float earthlife;

    public Earth()
    {
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Attack()
    {
        // Instantiate the projectile at the current position and rotation
        GameObject projectile = Instantiate(projectilePrefab, earthspawn.position, Quaternion.identity);
        // Set the projectile's velocity to shoot it along the x-axis
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
        }
        Destroy(projectile, earthlife); // Destroy the projectile after set time
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBats"))
        {
            EnemyAI enemy = collision.GetComponent<EnemyAI>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }
}
