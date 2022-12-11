using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints;

    [SerializeField] float coolDown;
    [SerializeField] int sizeOfWave;
    [SerializeField] int spawnedEnemy;

    private void Start()
    {
        sizeOfWave = Mathf.CeilToInt(Mathf.Pow(BaseManager.instance.wave, 1.4f) + 5 + Mathf.Sin(BaseManager.instance.wave));

        coolDown = (8 / (Mathf.Pow(BaseManager.instance.wave, 1.2f) + 2 + Mathf.Sin(BaseManager.instance.wave)));
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(coolDown);

      
        int randomPoint = Random.Range(0, spawnPoints.Length);

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[randomPoint].position, spawnPoints[randomPoint].rotation);

        newEnemy.GetComponent<Enemy>().mainBase = transform;

        spawnedEnemy++;

   

      

        StartCoroutine(Spawn());

        
        

       
    }
}
