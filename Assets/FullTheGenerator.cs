using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FullTheGenerator : MonoBehaviour
{
    [SerializeField] Generator generator;
    [SerializeField] Text interactionTest;




    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>()!=null)
        {
            interactionTest.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            interactionTest.gameObject.SetActive(false);
        }
    }
}
