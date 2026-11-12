using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shop : MonoBehaviour

{


    public int coins;
    public  TextMeshProUGUI coinText;




  

    public static Shop instance;
    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame


    public void Update()
    {
        coins = PlayerPrefs.GetInt("coins");
        coinText.text = "Coins: " + coins.ToString();
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }







}
