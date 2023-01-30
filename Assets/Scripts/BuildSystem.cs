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

                OpenBuildMenu();

            }

            else if (Input.GetKeyDown(KeyCode.Escape))
            {
                buildUserInterface.SetActive(false);
            }

            
        }

        if (canBuild)
        {
            PlaceBuild();

            if (Input.GetKey(KeyCode.R))
            {
                buildPreview.transform.Rotate(0,100*Time.deltaTime,0);
            }
        }



    }

    public void OpenBuildMenu()
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

    void PlaceBuild()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit, 30, buildLayer))
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

        if (BaseManager.instance.money >= build.price)
        {
            BaseManager.instance.money -= build.price;

            buildPreview = Instantiate(build.buildPreview,Vector3.zero,new Quaternion(0,0,0,0));
            
            buildPrefab = build.buildPrefab;

            buildUserInterface.SetActive(false);

            health = build.health;
             
            canBuild = true;
        }

    }


   
        
}
