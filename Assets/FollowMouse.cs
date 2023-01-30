using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    [SerializeField] float zDistance;

    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, zDistance));

        if (Input.GetKeyDown(KeyCode.A))
        {
            zDistance++;
        }
        
       else if (Input.GetKeyDown(KeyCode.D))
        {
            zDistance--;
        }

    }
}
