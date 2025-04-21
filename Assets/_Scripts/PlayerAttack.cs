using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private List<Element> elements; // List of elements
    [SerializeField] private List<Fire> fires; // List of elements
    [SerializeField] private List<Water> waters; // List of elements
    [SerializeField] private List<Earth> earths; // List of elements
    [SerializeField] private List<Lightning> lightnings; // List of elements
    [SerializeField] private float fireattackDelay;
    [SerializeField] private float waterattackDelay;
    [SerializeField] private float earthattackDelay;
    [SerializeField] private float lightningattackDelay;
    [field: SerializeField] public UnityEvent OnLevelUp { get; set; }
    [field: SerializeField] public UnityEvent OnElePickup { get; set; }
    [field: SerializeField] public UnityEvent OnAttack { get; set; }
    private bool isFireAttacking = false;
    private bool isWaterAttacking = false;
    private bool isEarthAttacking = false;
    private bool isLightningAttacking = false;
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
        if (!isEarthAttacking)
            StartCoroutine(EarthAttack());
        if (!isLightningAttacking)
            StartCoroutine(LightningAttack());
    }
    public void GotElement(Element element)
    {
        
        OnElePickup.Invoke();

        if (element is Fire)
        {
            fires.Add((Fire)element);
        }
        else if (element is Water)
        {
            waters.Add((Water)element);
        }
        else if (element is Earth)
        {
            earths.Add((Earth)element);
        }
        else if (element is Lightning)
        {
            lightnings.Add((Lightning)element);
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
        OnAttack.Invoke();
        foreach (Fire element in newfires)
        {
            element.Attack();
            yield return new WaitForSeconds(fireattackDelay / newfires.Count);
        }
        yield return new WaitForSeconds(fireattackDelay);
        isFireAttacking = false;
    }
    public IEnumerator WaterAttack()
    {
        List<Water> newwaters = new List<Water>(waters);
        isWaterAttacking = true;
        OnAttack.Invoke();
        foreach (Water element in newwaters)
        {
            element.Attack();
            yield return new WaitForSeconds(waterattackDelay / newwaters.Count);
        }
        yield return new WaitForSeconds(waterattackDelay);
        isWaterAttacking = false;
    }
    public IEnumerator EarthAttack()
    {
        List<Earth> newearths = new List<Earth>(earths);
        isEarthAttacking = true;
        OnAttack.Invoke();
        foreach (Earth element in newearths)
        {
            element.Attack();
            yield return new WaitForSeconds(earthattackDelay / newearths.Count);
        }
        yield return new WaitForSeconds(earthattackDelay);
        isEarthAttacking = false;
    }
    public IEnumerator LightningAttack()
    {
        List<Lightning> newlightnings = new List<Lightning>(lightnings);
        isLightningAttacking = true;
        OnAttack.Invoke();
        foreach (Lightning element in newlightnings)
        {
            element.Attack();
            yield return new WaitForSeconds(lightningattackDelay / newlightnings.Count);
        }
        yield return new WaitForSeconds(lightningattackDelay);
        isLightningAttacking = false;
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
        if (collision.CompareTag("EarthPickup"))
        {
            Earth earth = collision.GetComponent<Earth>();
            if (earth != null)
            {
                GotElement(earth);
                earth.gameObject.SetActive(false); // Deactivate the earth pickup object
            }
        }
        if (collision.CompareTag("LightningPickup"))
        {
            Lightning lightning = collision.GetComponent<Lightning>();
            if (lightning != null)
            {
                GotElement(lightning);
                lightning.gameObject.SetActive(false); // Deactivate the lightning pickup object
            }
        }

    }

}
