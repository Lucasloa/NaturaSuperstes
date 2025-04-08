using System;
using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    public bool isKnockback { get; private set; }
    private Rigidbody2D rb;
    [SerializeField] private float knockbackTime = 0.2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GetKnockback(Transform damagesource, float knockThrust)
    {
        isKnockback = true;
        Vector2 Difference = (transform.position - damagesource.position).normalized*knockThrust * rb.mass;
        rb.AddForce(Difference, ForceMode2D.Impulse);
        StartCoroutine(KnockbackCoroutine());
    }
    private IEnumerator KnockbackCoroutine()
    {
        yield return new WaitForSeconds(knockbackTime);
        rb.linearVelocity = Vector2.zero;
        isKnockback = false;
    }

    public void GetKnockback(object transform, float v)
    {
        throw new NotImplementedException();
    }
}
