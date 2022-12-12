using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] Transform basePoints;

    [SerializeField] float coolDown;
    [SerializeField] int sizeOfWave;
    [SerializeField] int spawnedEnemy;

    [SerializeField] List<GameObject> enemies = new List<GameObject>();

    public bool startWave;
    bool waveStarted;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        sizeOfWave = Mathf.CeilToInt(Mathf.Pow(BaseManager.instance.wave, 1.4f) + 5 + Mathf.Sin(BaseManager.instance.wave));

        coolDown = (8 / (Mathf.Pow(BaseManager.instance.wave, 1.2f) + 2 + Mathf.Sin(BaseManager.instance.wave)));

       
    }
    private void Update()
    {
        if (startWave && !waveStarted)
        {
            waveStarted = true;
            StartCoroutine(Spawn());
        }

        if (spawnedEnemy>=sizeOfWave)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i]==null)
                {
                    enemies.RemoveAt(i);
                }
            }

            if (enemies.Count==0)
            {
                spawnedEnemy =0;
                
                BaseManager.instance.wave++;
                
                StartCoroutine(Spawn());

            }

        }
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(coolDown);

      
        int randomPoint = Random.Range(0, spawnPoints.Length);

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoints[randomPoint].position, spawnPoints[randomPoint].rotation);

        newEnemy.GetComponent<Enemy>().mainBase = basePoints;

        enemies.Add(newEnemy);

        spawnedEnemy++;

        if (spawnedEnemy < sizeOfWave)
        {
            StartCoroutine(Spawn());
        }
       

        
        

       
    }
}
