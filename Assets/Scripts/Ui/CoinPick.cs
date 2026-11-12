using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPick : MonoBehaviour
{
    public int CoinsValue;


    private void Start()
    {
        CoinsValue *= PlayerPrefs.GetInt("CoinsValue");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.gameObject.tag == "Player")
        {
            Game_Controller.instance.UpdateCoins(CoinsValue);
            Destroy(gameObject);

        }
    }
}
