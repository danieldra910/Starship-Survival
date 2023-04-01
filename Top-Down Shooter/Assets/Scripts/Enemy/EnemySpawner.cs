using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] _enemyTypes;

    [SerializeField]
    Transform[] spawnLocations;
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        int random = Random.Range(0, 10);
        int randomLocation = Random.Range(0,spawnLocations.Length);
        yield return new WaitForSeconds(2);
        if(random ==9)
        {
            Instantiate(_enemyTypes[2], spawnLocations[randomLocation].position,Quaternion.identity);
        }
        else if(random >4)
        {
            Instantiate(_enemyTypes[1], spawnLocations[randomLocation].position, Quaternion.identity);
        }
        else
        {
            Instantiate(_enemyTypes[0], spawnLocations[randomLocation].position, Quaternion.identity);
        }
        StartCoroutine(SpawnEnemies());
    }
}
