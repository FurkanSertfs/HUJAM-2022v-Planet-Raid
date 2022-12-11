using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    [SerializeField] LayerMask buildLayer;
     GameObject buildPreview;
     GameObject buildPrefab;

    [SerializeField] GameObject buildUserInterface;

    public bool BuildUI = false;

    bool canBuild;

    int health;



    void Update()
    {

        if (!canBuild)
        {
            if (Input.GetKeyDown(KeyCode.B))

            {
                if (!buildUserInterface.activeSelf)
                {
                    buildUserInterface.SetActive(true);
                }

                else
                {
                    buildUserInterface.SetActive(false);
                }

            }

            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                buildUserInterface.SetActive(false);
            }

            if (canBuild)
            {
                PlaceBuild();
            }
        }
       
        

    }

 

    void PlaceBuild()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 100, buildLayer))
        {
            buildPreview.transform.position = hit.point;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (buildPreview.GetComponent<BuilderChacker>().canBuild)
                {
                    GameObject spawnBuild = Instantiate(buildPrefab, hit.point, buildPreview.transform.rotation);

               

                    spawnBuild.GetComponent<Build>().health = health;

                    Destroy(buildPreview);

                    canBuild = false;

                }




            }

        }
    }


    public void BuyBuild(BuildClass build)
    {
        bool haveResources = true;

        for (int i = 0; i < Player.instance.resources.Length; i++)
        {
            for (int j = 0; j < build.buildResources.Count; j++)
            {
                if (build.buildResources[j].resourcesType == Player.instance.resources[i].resourcesType)
                {
                    if (build.buildResources[j].resourcesCount > Player.instance.resources[i].Count)
                    {
                        haveResources = false;
                        break;
                    }

                }
            }
        }



        if (haveResources)
        {
            for (int i = 0; i < Player.instance.resources.Length; i++)
            {
                for (int j = 0; j < build.buildResources.Count; j++)
                {
                    if (build.buildResources[j].resourcesType == Player.instance.resources[i].resourcesType)
                    {
                         Player.instance.resources[i].Count-=build.buildResources[j].resourcesCount;

                    }
                }
            }

            buildPreview = Instantiate(build.buildPreview,Vector3.zero,new Quaternion(0,0,0,0));
            buildPrefab = build.buildPrefab;

            buildUserInterface.SetActive(false);

            health = build.health;
             
            canBuild = true;
        }

    }


   
        
}
