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

    [SerializeField] Image baseHealthBar;

     

    Vector3 scaleFactor;

   [SerializeField] bool totorial;

    float healthTimer;

    private void Start()
    {
        scaleFactor = transform.localScale;
        StartCoroutine(ElectricityGeneration());
        if (!totorial)
        {
            StartCoroutine(GeriSayim());

        }
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
        if (!totorial)
        {
            baseHealthBar.fillAmount = health / 500.0f;

        }

        if (health < 500)
        {
            if (healthTimer < Time.time)
            {
                health+=5;
                healthTimer = Time.time + 1.5f;

            }


        }

        if (EnemySpawner.instance.startWave)
        {
            waveText.text = "Wave : " + wave.ToString();

        }
       

        currentBataryImage.fillAmount = (float)currentBattery / batteryVolume;

        if (currentBattery >= batteryVolume)
        {
            currentBattery = batteryVolume;
        }

        if (currentBattery>=5000)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(3);


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
               
                AsyncOperation operation = SceneManager.LoadSceneAsync(2);
                Destroy(gameObject);
               

            }

        });
    }
}
