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
        List<Fire> newfires = new List<Fire>(fires);
        isFireAttacking = true;
        foreach (Fire element in newfires)
        {
            element.Attack();
            yield return new WaitForSeconds(attackDelay / newfires.Count);
        }
        yield return new WaitForSeconds(attackDelay);
        isFireAttacking = false;
    }
    public IEnumerator WaterAttack()
    {
        List<Water> newwaters = new List<Water>(waters);
        isWaterAttacking = true;
        foreach (Water element in newwaters)
        {
            element.Attack();
            yield return new WaitForSeconds(attackDelay / newwaters.Count);
        }
        yield return new WaitForSeconds(attackDelay);
        isWaterAttacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("FirePickup"))
        {
            Debug.Log("Fire");
            Fire fire = collision.GetComponent<Fire>();
            if (fire != null)
            {
                GotElement(fire);
                Debug.Log("Got added");
                fire.gameObject.SetActive(false); // Deactivate the fire pickup object
            }
        }
        if (collision.CompareTag("WaterPickup"))
        {
            Water water = collision.GetComponent<Water>();
            if (water != null)
            {
                GotElement(water);
                water.gameObject.SetActive(false); // Deactivate the water pickup object
            }
        }

    }

}
