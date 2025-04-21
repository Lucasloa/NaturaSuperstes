using UnityEngine;

public class Lightning : Element
{
    [SerializeField] public float damage;
    [SerializeField] private float levelBonus;
    [SerializeField] private GameObject projectilePrefab; // Reference to the projectile prefab
    [SerializeField] private float projectileSpeed = 10f; // Speed of the projectile    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform lightningspawn;
    [SerializeField] private float lightninglife;
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
        GameObject projectile = Instantiate(projectilePrefab, lightningspawn.position, Quaternion.identity);

        // Set the projectile's velocity to shoot it along the x-axis
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(0, -projectileSpeed);
        }
        Destroy(projectile, lightninglife); // Destroy the projectile after set time
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
