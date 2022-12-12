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

    public int wave;

    [SerializeField] Image currentBataryImage;
    
    [SerializeField] Text bataryText;

    [SerializeField] Text waveText;

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

        waveText.text = "Wave : " + wave.ToString();
       
        currentBataryImage.fillAmount = (float)currentBattery / batteryVolume;

        if (currentBattery >= batteryVolume)
        {
            currentBattery = batteryVolume;
        }

    }


    IEnumerator ElectricityGeneration()
    {

        yield return new WaitForSeconds(1);

        currentBattery += generatorCount;

        StartCoroutine(ElectricityGeneration());

    }


}
