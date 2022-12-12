using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class BaseManager : MonoBehaviour,IAttackable
{
    public static BaseManager instance;

    public int generatorCount;

    public int batteryVolume;

    public int currentBattery;

    public int wave;

    public int money;

    public  int health;

    [SerializeField] Image currentBataryImage;
    
    [SerializeField] Text bataryText;

    [SerializeField] Text waveText;

    [SerializeField] Text moneyText, moneyTextInMenu;

    [SerializeField ]int remaningTime;


    Vector3 scaleFactor;



    private void Start()
    {
        scaleFactor = transform.localScale;
        StartCoroutine(ElectricityGeneration());
        StartCoroutine(GeriSayim());
    }

    private void Awake()
    {
        instance = this;
        
    }

    IEnumerator GeriSayim()
    {
        yield return new WaitForSeconds(1);

        if (remaningTime==0)
        {
            EnemySpawner.instance.startWave = true;
        }
        else
        {
            waveText.text = remaningTime.ToString() + " Seconds Left On Enemy Attack";
            remaningTime--;
            StartCoroutine(GeriSayim());
        }

       
    }

    private void Update()
    {
        bataryText.text = currentBattery.ToString() +" / "+batteryVolume +" kW/h";

        moneyText.text = money.ToString();
        moneyTextInMenu.text = money.ToString();
        

        if (EnemySpawner.instance.startWave)
        {
            waveText.text = "Wave : " + wave.ToString();

        }
       

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

    public void Hit(int damage)
    {
        health -= damage;

        transform.DOShakeScale(0.2f, 0.2f, 16, 90, true).OnComplete(() =>

        {
            if (transform.localScale != scaleFactor)
            {
                transform.DOScale(scaleFactor, 0.05f);

            }

            if (health < 0)
            {
                Destroy(gameObject);
                GetComponent<Totorial>().finish = true;
                AsyncOperation operation = SceneManager.LoadSceneAsync(1);

            }

        });
    }
}
