using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseControl : MonoBehaviour
{
    [SerializeField] ThirdPersonShooterController shooterController;
    [SerializeField] StarterAssets.ThirdPersonController controller;
    [SerializeField] StarterAssets.StarterAssetsInputs inputs;
    [SerializeField] GameObject closeUI;

    private void OnEnable()
    {
        
        inputs.cursorLocked = false;
        controller.enabled = false;
        shooterController.enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        closeUI.SetActive(false);

    }
    private void OnDisable()
    {
        
      //  inputs.cursorLocked = true;
        controller.enabled = true;
        shooterController.enabled = true;
      //  Cursor.visible = false;
      //  Cursor.lockState = CursorLockMode.Locked;
        closeUI.SetActive(true);
    }

}
