using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerEnemyFinder : MonoBehaviour
{
    Tower tower;

    private void Start()
    {
        tower = GetComponentInParent<Tower>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            tower.enemies.Add(other.GetComponent<Enemy>());

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            tower.enemies.Remove(other.GetComponent<Enemy>());

            tower.SelectTarget();
        }
    }
}
