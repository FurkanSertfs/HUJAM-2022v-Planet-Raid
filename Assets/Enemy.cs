using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;


public class Enemy : MonoBehaviour
{
    
    public List<EnemyType> enemyTypes = new List<EnemyType>();
    
    public int health;

    int damage;

    Animator animator;

    NavMeshAgent agent;

    public Transform mainBase;

    public GameObject target;

    public List<GameObject> attackables = new List<GameObject>();

    public bool isAttacking;

    float scaleFactor;

    bool touchedEnemy;

    [SerializeField] GameObject touchedEnemyObject;

    public Transform targetPoint;

    int money;
    

    private void OnEnable()
    {
          int randomEnemy = Random.Range(0, Mathf.Min(BaseManager.instance.wave * 2, enemyTypes.Count));

       

        enemyTypes[randomEnemy].prefab.SetActive(true);
        enemyTypes[randomEnemy].weraponPrefab.SetActive(true);
        transform.localScale *= enemyTypes[randomEnemy].scaleFactor;
        scaleFactor = enemyTypes[randomEnemy].scaleFactor;
        health = enemyTypes[randomEnemy].health;
        damage = enemyTypes[randomEnemy].damage;
        money =Mathf.CeilToInt(enemyTypes[randomEnemy].health * 3.25f);


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

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.75f);

            if (touchedEnemyObject==null)
            {
                foreach (var hitCollider in hitColliders)
                {
                    if (hitCollider.GetComponent<IAttackable>() != null)
                    {
                        if (hitCollider != null)
                        {
                            touchedEnemy = true;

                            touchedEnemyObject = hitCollider.gameObject;
                            
                            animator.SetBool("isAttack", true);

                            agent.isStopped = true;

                            agent.ResetPath();
                        }


                    }

                    else
                    {
                        animator.SetBool("isAttack", false);

                        touchedEnemy = false;

                        touchedEnemyObject = null;

                        if (target == null)
                        {
                            SelectTarget();
                            if (mainBase != null)
                            {
                                GotoTarget(mainBase.position);

                            }


                        }

                        else
                        {

                            GotoTarget(target.transform.position);

                        }


                    }

                }
            }
            else
            {
                touchedEnemy = true;

                animator.SetBool("isAttack", true);

                agent.isStopped = true;

                agent.ResetPath();
            }
            

            
        }

        else
        {
            if (agent)
            {
                agent.isStopped = true;

                agent.ResetPath();

                animator.SetBool("isDying", true);

                BaseManager.instance.money += money;
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

      

        if (touchedEnemyObject!=null)
        {
            touchedEnemyObject.GetComponent<IAttackable>().Hit(damage);

            

        }
        touchedEnemyObject = null;
        touchedEnemy = false;

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
