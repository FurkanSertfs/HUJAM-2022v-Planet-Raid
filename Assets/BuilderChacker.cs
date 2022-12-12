using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuilderChacker : MonoBehaviour
{
    MeshRenderer[] renderer;

    List<MaterialArray> startMaterials = new List<MaterialArray>();

    [SerializeField] Material redMatirial;

    List<Material> Redmaterials = new List<Material>();

    public bool canBuild;

    private void Start()
    {
        renderer = GetComponentsInChildren<MeshRenderer>();
        canBuild = true;

        for (int i = 0; i < 4; i++)
        {
            Redmaterials.Add(redMatirial);
        }

        for (int i = 0; i < renderer.Length; i++)
        {
            startMaterials.Add(new MaterialArray());
            startMaterials[i].startMaterials = renderer[i].materials;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if (other.GetComponent<CantBuildHere>()!=null)
        {
           

            canBuild = false;

            for (int i = 0; i < renderer.Length; i++)
            {
                renderer[i].materials= Redmaterials.ToArray();
            }
          
        }
           
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<CantBuildHere>() != null)
        {
          
            canBuild = true;


            for (int i = 0; i < renderer.Length; i++)
            {
                renderer[i].materials = startMaterials[i].startMaterials;
            }

          
        }


    }
}
[System.Serializable]
public class MaterialArray
{
   public Material[] startMaterials;
}
