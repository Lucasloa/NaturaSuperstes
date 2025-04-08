using UnityEngine;

public class Water : Element
{
    [SerializeField] private float damage;
    [SerializeField] private float levelBonus;
    [SerializeField] private GameObject projectilePrefab; // Reference to the projectile prefab
    [SerializeField] private float projectileSpeed = 10f; // Speed of the projectile    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform waterballspawn;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    public override void Attack()
    {
        this.damage = damage;

        // Instantiate the projectile at the current position and rotation
        GameObject projectile = Instantiate(projectilePrefab, waterballspawn.position, Quaternion.identity);

        // Set the projectile's velocity to shoot it along the x-axis
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(0, projectileSpeed);
        }
    }
}
