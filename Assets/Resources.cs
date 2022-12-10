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


            for (int i = 0; i < other.GetComponent<Player>().resources.Length; i++)
            {
                if (resourcesType == other.GetComponent<Player>().resources[i].resourcesType)
                {
                   
                    other.GetComponent<Player>().resources[i].Count++;
                }
            }

            Destroy(gameObject);

        }


        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {

            Debug.Log("Cikis");


        }



    }

}
