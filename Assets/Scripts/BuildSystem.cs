using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{
    [SerializeField] LayerMask buildLayer;
    public GameObject Tower;
    public GameObject TowerPrev;


    public bool BuildUI = false;    
   

    void Update()
    {
      
        if (Input.GetKeyDown(KeyCode.B))
        {
            BuildUI = !BuildUI;
        }

        if (BuildUI == true)
        {
           
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100,buildLayer))
            {
               TowerPrev.transform.position = hit.point;
               
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (TowerPrev.GetComponent<BuilderChacker>().canBuild)
                    {
                        GameObject spawnPositon = Instantiate(Tower, hit.point, Quaternion.Euler(new Vector3(0, -90, -90)));
                        spawnPositon.transform.Rotate(0f, -90f, 0f);

                    }


                   

                }

            }
        }
    }
    public void OpenUI()
    {

        BuildUI = true;
        
    }
        
}
