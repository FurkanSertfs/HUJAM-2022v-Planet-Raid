using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Build : MonoBehaviour , IAttackable
{
    public int health;

    public void Hit(int damage)
    {
        health -= damage;
    }
}
