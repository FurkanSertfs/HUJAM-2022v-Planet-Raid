using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorResources : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Generator>()!=null)
        {
            other.GetComponent<Generator>().resourcesCount++;
            Destroy(gameObject);
        }
    }
}
