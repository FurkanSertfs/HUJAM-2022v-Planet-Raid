using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderChacker : MonoBehaviour
{
    MeshRenderer renderer;

    Material[] startMaterials;

    [SerializeField] Material[] redMatirial;

    public bool canBuild;

    private void Start()
    {
        renderer = GetComponentInChildren<MeshRenderer>();
        canBuild = true;
        startMaterials = renderer.materials ;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Build>()!=null)
        {

            canBuild = false;
            renderer.materials = redMatirial;
        }
           
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Build>() != null)
        {

            canBuild = true;
            renderer.materials = startMaterials;
        }


    }
}
