using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    
    public List<EnemyType> enemyTypes = new List<EnemyType>();
    
    [SerializeField] int health;

    int damage;

    Animator animator;

    NavMeshAgent agent;

    public Transform mainBase;

    public GameObject target;

    public List<GameObject> attackables = new List<GameObject>();

    public bool isAttacking;

    float scaleFactor;

    bool touchedEnemy;

    GameObject touchedEnemyObject;

    private void OnEnable()
    {
        int randomEnemy = Random.Range(0, Mathf.Min(BaseManager.instance.wave * 2, enemyTypes.Count));

        enemyTypes[randomEnemy].prefab.SetActive(true);
        enemyTypes[randomEnemy].weraponPrefab.SetActive(true);
        transform.localScale *= enemyTypes[randomEnemy].scaleFactor;
        scaleFactor = enemyTypes[randomEnemy].scaleFactor;
        health = enemyTypes[randomEnemy].health;
        damage = enemyTypes[randomEnemy].damage;


    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (health > 0)
        {
            if (target == null)
            {

                if (!CheckArrive())
                {
                    SelectTarget();
                    if (mainBase!=null)
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
            if (agent)
            {
                agent.isStopped = true;

                agent.ResetPath();

                animator.SetBool("isDying", true);
            }
          

            Destroy(agent);

            
        }


    }
    public void Death()
    {

        Destroy(gameObject);

    }

    


    public void Attack( )
    {

        touchedEnemyObject.GetComponent<IAttackable>().Hit(damage);


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

        transform.DOShakeScale(0.2f,0.2f,16,90,true).OnComplete(()=> 
        
        {
            if (transform.localScale.x != scaleFactor)
            {
                transform.DOScale(new Vector3(scaleFactor, scaleFactor, scaleFactor),0.05f);

            }

        });
       

    }




    public void GotoTarget(Vector3 point)
    {

        agent.SetDestination(point);

    }
    public bool CheckArrive()
    {
        if (touchedEnemy)
        {
            Debug.Log("True");

            animator.SetBool("isAttack", true);

            agent.isStopped = true;

            agent.ResetPath();

            return true;
        }

        if (agent.hasPath && agent.remainingDistance < 0.5f)
        {
            animator.SetBool("isAttack", true);

            agent.isStopped = true;

            agent.ResetPath();

            return true;


        }

        else if (agent.hasPath && agent.remainingDistance >= 0.5f)
        {
            agent.isStopped = false;

            animator.SetBool("isAttack", false);

            return false;
        }

        return false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IAttackable>() != null)
        {
            touchedEnemy = true;
            touchedEnemyObject = other.gameObject;
        }

    }

    private void OnTriggerExit(Collider other)
    {

        if (other.GetComponent<IAttackable>() != null)
        {
            touchedEnemy = false;
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
    public float fireSpeed;
}
