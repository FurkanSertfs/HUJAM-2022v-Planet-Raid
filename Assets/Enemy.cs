using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    [NonReorderable]
    public List<EnemyType> enemyTypes = new List<EnemyType>();
    
    int health;

    int damage;

    Animator animator;

    NavMeshAgent agent;

    public Transform mainBase;

    public GameObject target;

    public List<GameObject> attackables = new List<GameObject>();

    public bool isAttacking;
    

    private void OnEnable()
    {
        int randomEnemy = Random.Range(0, enemyTypes.Count);

        enemyTypes[randomEnemy].prefab.SetActive(true);
        enemyTypes[randomEnemy].weraponPrefab.SetActive(true);
        transform.localScale *= enemyTypes[randomEnemy].scaleFactor;
        health = enemyTypes[randomEnemy].health;
        damage = enemyTypes[randomEnemy].damage;


    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (health>0)
        {
            if (target == null)
            {

                if (!CheckArrive())
                {
                    SelectTarget();
                    if (!mainBase)
                    {
                        GotoTarget(mainBase.position);

                    }
                }

            }

            else
            {
                if (!CheckArrive())
                {

                    GotoTarget(target.transform.position);
                }
            }
        }

        else
        {
            agent.isStopped = true;

            agent.ResetPath();

            animator.SetBool("isDying", true);

        }
        

    }

    public void Attack(GameObject gameObject)
    {
        if (isAttacking)
        {
            gameObject.GetComponent<IAttackable<int>>().Hit(damage);

        }

    }


    void SelectTarget()
    {
        if (attackables.Count > 0)
        {
            if (attackables[0].gameObject != null)
            {
                target = attackables[0];
            }

            else
            {
                attackables.RemoveAt(0);
               
                target = null;
            }


        }

        else
        {
            target = null;
        }
    }

    public void Hit()
    {
        health -=10;
        
       

    }




    public void GotoTarget(Vector3 point)
    {

        agent.SetDestination(point);

    }
    public bool CheckArrive()
    {

        if (agent.hasPath && agent.remainingDistance < 0.1f)
        {
            animator.SetBool("isAttack", true);

            agent.isStopped = true;

            agent.ResetPath();

            return true;


        }

        else if (agent.hasPath && agent.remainingDistance > 0.25f)
        {
            agent.isStopped = false;

            animator.SetBool("isAttack", false);

            return false;
        }

        return false;

    }

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IAttackable<int>>() !=null)
        {
            attackables.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<IAttackable<int>>() != null)
        {
            attackables.Remove(other.gameObject);
        }
    }

}









[System.Serializable]
public class EnemyType
{
    public GameObject prefab;
    public float scaleFactor;
    public GameObject weraponPrefab;
    public int health;
    public int damage;

}
