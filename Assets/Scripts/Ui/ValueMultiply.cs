using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueMultiply : MonoBehaviour
{
    public int CoinsValue;
    public int CoinsMultiplie = 100;
    public int coins;

    public GameObject NotValue;
    public GameObject Comprado;

    public float delayInSeconds = 2f;



    // Start is called before the first frame update
    void Start()
    {
        
        coins = PlayerPrefs.GetInt("coins");
        CoinsValue = PlayerPrefs.GetInt("CoinsValue");
    }

    // Update is called once per frame
    public void ValueBuy()
    {
        if (coins < 100)
        {
            NotValue.SetActive(true);
            Invoke("DisableObject", delayInSeconds);
        }
        else
        {
            CoinsValue += 1;
            PlayerPrefs.SetInt("CoinsValue", CoinsValue);
            coins -= CoinsMultiplie;
            PlayerPrefs.SetInt("coins", coins);
            Comprado.SetActive(true);
            Invoke("DisableObject", delayInSeconds);
        }
    }

    public void DisableObject()
    {
        NotValue.SetActive(false);
        Comprado.SetActive(false);
    }
}
