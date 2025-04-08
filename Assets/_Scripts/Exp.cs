using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class Exp : MonoBehaviour
{
    [field: SerializeField]
    private int currentExp; // Current experience points
    private int level;
    private int expToLevelUp; // Experience points required to level up
    private static System.Random _random = new System.Random();
    private int _facevalue;
    [SerializeField] private GameObject firePrefab;
    [SerializeField] private GameObject waterPrefab;
    [SerializeField] private Transform waterPrefabspawn;
    [SerializeField] private Transform firePrefabspawn;


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
        _facevalue = _random.Next(0, 2);
        if (_facevalue == 0)
        {
            Debug.Log("Fire");
            Instantiate(firePrefab, waterPrefabspawn.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Water");

            Instantiate(waterPrefab, firePrefabspawn.position, Quaternion.identity);

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
