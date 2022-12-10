using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery : MonoBehaviour
{
    private void Start()
    {
        BaseManager.instance.batteryVolume += 500;

    }

    private void OnDisable()
    {
        BaseManager.instance.batteryVolume -= 500;
    }
}
