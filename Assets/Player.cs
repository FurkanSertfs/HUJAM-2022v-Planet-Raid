using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour,IAttackable
{
    public static Player instance;
    public Transform collectPoint;

    public int health;

    public Resource[] resources;

    public void Hit(int damage)
    {
        health -= damage;
    }

    private void Awake()
    {
        instance = this;
    }
}

[System.Serializable]
public class Resource
{
    public Resources.ResourcesType resourcesType;
    public int Count;

}
