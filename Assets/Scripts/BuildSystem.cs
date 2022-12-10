using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSystem : MonoBehaviour
{

    public GameObject Tower;
    public GameObject TowerPrev;

    Transform socket;

    public bool BuildUI = false;    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.B))
        {
            BuildUI = !BuildUI;
        }

        if (BuildUI == true)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.transform.tag == "Socket")
                {
                    socket = hit.transform;

                    TowerPrev.transform.position = socket.transform.position;

                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        GameObject spawnPositon = Instantiate(Tower, socket.transform.position, Quaternion.identity);
                        spawnPositon.transform.Rotate(180f, 180f, 0f);

                        Debug.Log("ge1");
                    }
                }
                else
                {
                    TowerPrev.transform.position = hit.point;
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        GameObject spawnPositon = Instantiate(Tower, hit.point, Quaternion.Euler(new Vector3(0, -90, -90)));
                        spawnPositon.transform.Rotate(0f, -90f, 0f);

                        Debug.Log("ge");

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
