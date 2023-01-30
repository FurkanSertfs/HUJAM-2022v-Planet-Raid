using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using StarterAssets;

public class FireButton : MonoBehaviour
{
    [SerializeField]
    private StarterAssetsInputs starterAssetsInputs;

    public void Fire()
    {
        starterAssetsInputs.shoot = true;
        starterAssetsInputs.aim = true;
       
    }
}
