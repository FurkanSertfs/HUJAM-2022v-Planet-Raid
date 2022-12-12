using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Player : MonoBehaviour,IAttackable
{
    public static Player instance;
    public Transform collectPoint;
    [SerializeField] Text generatorInteractionText;
    [SerializeField] GameObject mineResources;
    [SerializeField] Image croshair;
    [SerializeField] Image healthBar;
    [SerializeField] Text resourcesText;
    

    public int resourcesCount;
    public int health;

   // public Resource[] resources;

    float timer;

    public void Hit(int damage)
    {
        health -= damage;
    }

    private void Update()
    {
        healthBar.fillAmount = health / 100.0f;


        resourcesText.text = resourcesCount.ToString();

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out RaycastHit hit2, 50))
        {
            if (hit2.collider.GetComponent<Enemy>()!=null || hit2.collider.GetComponent<Mine>() != null)
            {
                croshair.color = Color.green;
            }
            else
            {
                croshair.color = Color.white;

            }

        }
        else
        {
            croshair.color = Color.white;
        }

            if (Physics.Raycast(ray, out RaycastHit hit, 10))
        {
            if (hit.collider.GetComponent<Generator>()!=null)
            {
                generatorInteractionText.gameObject.SetActive(true);

                if (Input.GetKey(KeyCode.E))
                {
                    
                   
                    if (timer <= Time.time && resourcesCount >= 1)
                    {
                        GameObject resource = Instantiate(mineResources, collectPoint.position,collectPoint.rotation);

                        resource.transform.DOMove(hit.collider.GetComponent<Generator>().collectPoint.position,0.45f);

                        timer =Time.time + 0.1f;
                        
                        resourcesCount--;
                    }

                }
            }

            else
            {
            
                generatorInteractionText.gameObject.SetActive(false);
            }


        }
        else
        {
          
            generatorInteractionText.gameObject.SetActive(false);
        }

    }

 



    private void Awake()
    {
        instance = this;
    }
}

[System.Serializable]
public class Resource
{
    public Resources.ResourcesType resourcesType;
    public int Count;

}
