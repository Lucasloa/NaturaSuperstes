using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [field: SerializeField]
    public List<GameObject> Spawnpoints;
    [field: SerializeField]
    public GameObject spawnMonster { get; set; }
    [field: SerializeField]
    public int count { get; set; }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Instantiate(spawnMonster, Spawnpoints[Random.Range(0, Spawnpoints.Count)].transform.position, Quaternion.identity);
        //spawnObject(spawnMonster, Spawnpoints[0].transform.position);
        //spawnObject(spawnMonster, Spawnpoints[1].transform.position);
        //spawnObject(spawnMonster, Spawnpoints[2].transform.position);
        //spawnObject(spawnMonster, Spawnpoints[3].transform.position);
        StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnObject(GameObject spawnObject, Vector3 spawnPosition)
    {
        Instantiate(spawnObject, spawnPosition, Quaternion.identity);
    }
    IEnumerator SpawnCoroutine()
    {
        while (count > 0)
        {
            count--;
            int randomSpawnPoint = Random.Range(0, Spawnpoints.Count);
            var randomOffset = Random.insideUnitSphere;
            var spawnPosition = Spawnpoints[randomSpawnPoint].transform.position + (Vector3)randomOffset;
            spawnObject(spawnMonster, spawnPosition);
            yield return new WaitForSeconds(1);

        }
    }
}
