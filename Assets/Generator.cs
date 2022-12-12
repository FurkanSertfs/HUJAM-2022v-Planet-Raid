using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Generator : MonoBehaviour
{
    public int resourcesCount;

    public Transform collectPoint;

    [SerializeField] Text remaningResources;
    [SerializeField] Image processingBar;
    [SerializeField] Text processingActive;
    [SerializeField] Text productionAmount;
    [SerializeField] AudioSource audioSource;
    [SerializeField] Animator animator;

    int progressCount;

    private void Update()
    {
        remaningResources.text = "Remaning Resources :"+resourcesCount;

        if (resourcesCount>=1)
        {
            animator.SetBool("isActive",true);
            processingActive.text = "Processing...";
            processingBar.fillAmount += Time.deltaTime;
            productionAmount.text = "+40 Kw/s";

            if (processingBar.fillAmount >= 1)
            {
                audioSource.pitch = Random.Range(0.8f,1);
                audioSource.Play();

                processingBar.fillAmount = 0;

                BaseManager.instance.currentBattery += 40;

                progressCount++;

                if (progressCount>=5)
                {
                    progressCount = 0;
                    resourcesCount--;
                }

            }
        }

        else
        {
            animator.SetBool("isActive", false);

            processingActive.text = "Missing resource !!!";
            productionAmount.text = "+0 Kw/s";
        }
       
    }

   
}
