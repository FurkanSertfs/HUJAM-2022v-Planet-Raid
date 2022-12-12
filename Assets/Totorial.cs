using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Totorial : MonoBehaviour
{
    [SerializeField] Text collectMine;
    [SerializeField] Text PressB;
    [SerializeField] Text placeGenerator;
    [SerializeField] Text fillTheGenrator;
    [SerializeField] GameObject startGame;


    public bool finish;

    bool first,buyGenerator;

    private void Update()
    {
        if (Player.instance.resourcesCount >= 10&&!first)
        {
            first = true;
            collectMine.gameObject.SetActive(false);
            placeGenerator.gameObject.SetActive(true);
            PressB.gameObject.SetActive(true);

           
           
        }

        if (first)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                PressB.gameObject.SetActive(false);
            }
        }

        if (buyGenerator)
        {
            PressB.gameObject.SetActive(false);
            placeGenerator.gameObject.SetActive(false);
            fillTheGenrator.gameObject.SetActive(true);

        }
        if (finish)
        {
            StartCoroutine(Wait());

        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
        startGame.gameObject.SetActive(true);
    }


    public void BuyGenerator()
    {
        buyGenerator = true;
    }
}
