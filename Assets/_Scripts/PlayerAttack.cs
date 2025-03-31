using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private List<Element> elements; // List of elements
    [SerializeField] private List<Fire> fires; // List of elements
    [SerializeField] private List<Water> waters; // List of elements
    [SerializeField] private float attackDelay;
    private bool isFireAttacking = false;
    private bool isWaterAttacking = false;
    //private bool isAttacking = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isFireAttacking)
        StartCoroutine(FireAttack());
        if (!isWaterAttacking)
            StartCoroutine(WaterAttack());
    }
    public void GotElement(Element element)
    {
        if (element is Fire)
        {
            fires.Add((Fire)element);
        }
        else if (element is Water)
        {
            waters.Add((Water)element);
        }
        //elements.Add(element);
    }
    //public IEnumerator Attack()
    //{
    //    isAttacking = true;
    //    foreach (Element element in elements)
    //    {
    //        element.Attack();
    //        yield return new WaitForSeconds(attackDelay / elements.Count);
    //    }
    //    isAttacking = false;
    //}
    public IEnumerator FireAttack()
    {
        isFireAttacking = true;
        foreach (Fire element in fires)
        {
            element.Attack();
            yield return new WaitForSeconds(attackDelay / fires.Count);
        }
        yield return new WaitForSeconds(attackDelay);
        isFireAttacking = false;
    }
    public IEnumerator WaterAttack()
    {
        isWaterAttacking = true;
        foreach (Water element in waters)
        {
            element.Attack();
            yield return new WaitForSeconds(attackDelay / waters.Count);
        }
        yield return new WaitForSeconds(attackDelay);
        isWaterAttacking = false;
    }
}
