using System.Collections;
using UnityEngine;

public abstract class Element : MonoBehaviour
{
    public float LevelBonus { get; set; }
    [SerializeField] public float attackDelay = 0.50f;
    public bool isAttacking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    }

    public virtual void Attack()
    {
    }

    public virtual void LevelbonusCalc(float level)
    {
    }
}
