using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class TestInput : MonoBehaviour
{
    public StarterAssetsInputs assetsInputs;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {

            assetsInputs.move.x = 1;
            Debug.Log(assetsInputs.move.x);
        }
    }
}
