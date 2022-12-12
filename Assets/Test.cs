using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] int speed;
    void Start()
    {
        Time.timeScale = speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
