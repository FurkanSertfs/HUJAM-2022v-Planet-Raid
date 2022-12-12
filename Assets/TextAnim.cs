using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextAnim : MonoBehaviour
{
    Text mainText;

    bool isActive;

    private void Start()
    {
        mainText = GetComponent<Text>();
    }

    private void OnEnable()
    {
       
        StartCoroutine(OpenClose(true));

        
    }

    IEnumerator OpenClose(bool aktive)
    {
        yield return new WaitForSeconds(0.3f);
        mainText.enabled = aktive;
        
        StartCoroutine(OpenClose(!aktive));

    }
}
