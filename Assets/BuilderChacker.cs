using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderChacker : MonoBehaviour
{
    MeshRenderer[] renderer;

    Material[] startMaterials;

    [SerializeField] Material[] redMatirial;

    public bool canBuild;

    private void Start()
    {
        renderer = GetComponentsInChildren<MeshRenderer>();
        canBuild = true;

        for (int i = 0; i < renderer.Length; i++)
        {
            startMaterials = renderer[i].materials;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Build>()!=null)
        {
            Debug.Log("Builds");

            canBuild = false;

            for (int i = 0; i < renderer.Length; i++)
            {
                renderer[i].materials= redMatirial;
            }
          
        }
           
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Build>() != null)
        {

            canBuild = true;


            for (int i = 0; i < renderer.Length; i++)
            {
                renderer[i].materials = startMaterials;
            }

          
        }


    }
}
