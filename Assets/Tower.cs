using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Tower : MonoBehaviour
{
    List<Enemy> enemies = new List<Enemy>();

    [SerializeField] float fireRate;

    Transform target;

    [SerializeField] Transform spawnBulletPosition;
    [SerializeField] Transform bulletProjectile;
    [SerializeField] int fireCost;

    bool isFiring;

    Quaternion startRotation;

    private void Start()
    {
        startRotation = transform.rotation;
    }

    private void Update()
    {
        if (target==null)
        {
            SelectTarget();

            transform.DORotateQuaternion(startRotation, 0.5f);

        }

        else
        {
            transform.LookAt(target);

            Fire();
        }

    }

    void Fire() 
    {
        if (!isFiring)
        {
            isFiring = true;

            StartCoroutine(FireRuotine());
        }

    
    }

    IEnumerator FireRuotine()
    {
        yield return new WaitForSeconds(fireRate);

        if (target!=null && BaseManager.instance.currentBattery >= fireCost)
        {
            Vector3 aimDir = (target.position - spawnBulletPosition.position).normalized;

            Instantiate(bulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));

            BaseManager.instance.currentBattery -=fireCost;
            
           
        }

        isFiring = false;

    }





    void SelectTarget()
    {
        if (enemies.Count>0)
        {
            if (enemies[0].gameObject !=null)
            {
                target = enemies[0].transform;
            }
            else
            {
                enemies.RemoveAt(0);
                target = null;
            }

            
        }

        else
        {
            target = null;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>()!=null)
        {
            enemies.Add(other.GetComponent < Enemy>());

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            enemies.Remove(other.GetComponent<Enemy>());

            SelectTarget();
        }
    }
}
