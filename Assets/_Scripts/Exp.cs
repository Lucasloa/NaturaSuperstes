using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Exp : MonoBehaviour
{
    [field: SerializeField]
    private int currentExp; // Current experience points
    private int level = 1;
    private int expToLevelUp = 3; // Experience points required to level up
    private static System.Random _random = new System.Random();
    private int _facevalue;
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private GameObject waterPrefab;
    [SerializeField] private GameObject lightningPrefab;
    [SerializeField] private Transform waterPrefabspawn;
    [SerializeField] private Transform firePrefabspawn;
    [SerializeField] private Transform lightningPrefabspawn;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelUp()
    {
        Debug.Log("leveledup");
        level++;
        _facevalue = _random.Next(0, 100);
        Debug.Log("Face value: " + _facevalue);
        if (_facevalue < 33)
        {
            Debug.Log("Fire");
            Instantiate(firePrefab, waterPrefabspawn.position, Quaternion.identity);
        }
        else if(_facevalue > 33 && _facevalue < 66)
        {
            Debug.Log("Water");

            Instantiate(waterPrefab, firePrefabspawn.position, Quaternion.identity);

        }
        else if (_facevalue > 66)
        {
            Debug.Log("Lightning");
            Instantiate(lightningPrefab, lightningPrefabspawn.position, Quaternion.identity);
        }
    }

    public void AddExp(int amount)
    {
        currentExp += amount;
        Debug.Log("Current Exp: " + currentExp);
        if (currentExp >= expToLevelUp * level)
        { 
            LevelUp();
            currentExp = 0;
        }
    }
}
