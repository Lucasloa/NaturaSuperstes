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
    public int Batcount { get; set; }
    [field: SerializeField]
    public GameObject spawnGhost { get; set; }
    [field: SerializeField]
    public int Ghostcount { get; set; }




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Instantiate(spawnMonster, Spawnpoints[Random.Range(0, Spawnpoints.Count)].transform.position, Quaternion.identity);
        //spawnObject(spawnMonster, Spawnpoints[0].transform.position);
        //spawnObject(spawnMonster, Spawnpoints[1].transform.position);
        //spawnObject(spawnMonster, Spawnpoints[2].transform.position);
        //spawnObject(spawnMonster, Spawnpoints[3].transform.position);
        StartCoroutine(SpawnMonsterCoroutine());
        StartCoroutine(SpawnGhostCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnObject(GameObject spawnObject, Vector3 spawnPosition)
    {
        Instantiate(spawnObject, spawnPosition, Quaternion.identity);
    }
    IEnumerator SpawnMonsterCoroutine()
    {
        while (Batcount > 0)
        {
            Batcount--;
            int randomSpawnPoint = Random.Range(0, Spawnpoints.Count);
            var randomOffset = Random.insideUnitSphere;
            var spawnPosition = Spawnpoints[randomSpawnPoint].transform.position + (Vector3)randomOffset;
            spawnObject(spawnMonster, spawnPosition);
            yield return new WaitForSeconds(1);

        }
    }
    IEnumerator SpawnGhostCoroutine()
    {
        while (Ghostcount > 0)
        {
            Ghostcount--;
            int randomSpawnPoint = Random.Range(0, Spawnpoints.Count);
            var randomOffset = Random.insideUnitSphere;
            var spawnPosition = Spawnpoints[randomSpawnPoint].transform.position + (Vector3)randomOffset;
            spawnObject(spawnGhost, spawnPosition);
            yield return new WaitForSeconds(1);

        }
    }
}
