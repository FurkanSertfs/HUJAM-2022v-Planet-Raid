using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour
{
    private void LateUpdate()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.y+= 30;
        transform.rotation = Quaternion.Euler(rotationVector);
    }
}
