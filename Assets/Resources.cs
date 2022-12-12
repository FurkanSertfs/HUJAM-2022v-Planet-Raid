using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public enum ResourcesType { Uranium,Titanium }

    [SerializeField]  ResourcesType resourcesType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>()!=null)
        {

            other.GetComponent<Player>().resourcesCount++;



            Destroy(gameObject);

        }


        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {

           


        }



    }

}
