using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BaseManager : MonoBehaviour
{
    public static BaseManager instance;

    public int generatorCount;

    public int batteryVolume;

    public int currentBattery;

    [SerializeField] Image currentBataryImage;
    [SerializeField] Text bataryText;

    private void Start()
    {
        StartCoroutine(ElectricityGeneration());
    }

    private void Awake()
    {
        instance = this;
        
    }

    private void Update()
    {
        bataryText.text = currentBattery.ToString() +" / "+batteryVolume +" kW/h";
        currentBataryImage.fillAmount = (float)currentBattery / batteryVolume;

    }


    IEnumerator ElectricityGeneration()
    {

        yield return new WaitForSeconds(1);

        currentBattery += generatorCount * 50;

        StartCoroutine(ElectricityGeneration());

    }


}
