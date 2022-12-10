using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Transform collectPoint;

    public Resource[] resources;

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
