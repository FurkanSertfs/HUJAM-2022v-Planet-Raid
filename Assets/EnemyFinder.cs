using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    Enemy enemy;

    private void Start()
    {
        enemy = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter(Collider other)
    {

        

        if (other.GetComponent<IAttackable>() != null)
        {
            enemy.attackables.Add(other.gameObject);
        }
        else if (other.GetComponent<BaseManager>() != null)
        {

        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<IAttackable>() != null)
        {
            enemy.attackables.Remove(other.gameObject);
        }
    }
}
