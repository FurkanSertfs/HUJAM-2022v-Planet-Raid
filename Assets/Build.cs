using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Build : MonoBehaviour , IAttackable
{
    public int health;

    Vector3 scaleFactor;

    private void Start()
    {
        scaleFactor = transform.localScale;
    }

    public void Hit(int damage)
    {
        health -= damage;

        transform.DOShakeScale(0.2f, 0.2f, 16, 90, true).OnComplete(() =>

        {
            if (transform.localScale != scaleFactor)
            { 
                transform.DOScale(scaleFactor, 0.05f);

            }

            if (health < 0)
            {
                Destroy(gameObject);
                GetComponent<Totorial>().finish = true;
            }

        });

       
    }
}
