using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints;

    [SerializeField] float coolDown;
    [SerializeField] int sizeOfWave;

    private void Start()
    {
        
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(coolDown);

        for (int i = 0; i < sizeOfWave; i++)
        {
            int randomPoint = Random.Range(0, spawnPoints.Length);

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[randomPoint].position, spawnPoints[randomPoint].rotation);

            newEnemy.GetComponent<Enemy>().mainBase = transform;

            StartCoroutine(Spawn());
        }

       

        

       
    }
}
