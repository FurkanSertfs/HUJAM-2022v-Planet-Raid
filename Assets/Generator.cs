using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{

   

    private void Start()
    {
        BaseManager.instance.generatorCount++;

    }

    private void OnDisable()
    {
        BaseManager.instance.generatorCount--;

    }
}
