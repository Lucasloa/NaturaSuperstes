using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : Element
{
    //private Animator animator;
    //private bool IsFireAttacking = false;
    [SerializeField] public float damage;
    [SerializeField] private float levelBonus;
    [SerializeField] private GameObject projectilePrefab; // Reference to the projectile prefab
    [SerializeField] private float projectileSpeed = 10f; // Speed of the projectile    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private Transform fireballspawn;
    [SerializeField] private float fireballlife;
    public Fire()
    {
    }
    void Start()
    {
        
    }

    //private void Awake()
    //{
    //    animator = GetComponent<Animator>();
    //}
    // Update is called once per frame
    void FixedUpdate()
    {
    }
    public override void Attack()
    {
        //if (!IsFireAttacking)
        //{
        //    animator.SetBool("IsFireAttacking", true);
        //}

        // Instantiate the projectile at the current position and rotation
        GameObject projectile = Instantiate(projectilePrefab, fireballspawn.position, Quaternion.identity);

        // Set the projectile's velocity to shoot it along the x-axis
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = new Vector2(projectileSpeed, 0);
        }
        Destroy(projectile, fireballlife); // Destroy the projectile after set time
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
