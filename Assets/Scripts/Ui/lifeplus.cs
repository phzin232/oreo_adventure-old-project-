using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class lifeplus : MonoBehaviour
{
    public int maxHealth;
    public int coins;

    private int LifeValue = 50;

    public float delayInSeconds = 2f;

   

    public GameObject BaixoValor;
    public GameObject Comprado;

    // Start is called before the first frame update
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
        maxHealth = PlayerPrefs.GetInt("maxHealth");
    }

    // Update is called once per frame
 
    public void LifeBuy()
    {
        if(coins < 50)
        {
            BaixoValor.SetActive(true);
            Invoke("DisableObject", delayInSeconds);
        }
        else
        {
            maxHealth += 1;
            PlayerPrefs.SetInt("maxHealth", maxHealth);
            coins -= LifeValue;
            PlayerPrefs.SetInt("coins", coins);
            Comprado.SetActive(true);
            Debug.Log(maxHealth);
            Invoke("DisableObject", delayInSeconds);
        }
    }
    public void DisableObject()
    {
        BaixoValor.SetActive(false);
        Comprado.SetActive(false) ;
    }


}
