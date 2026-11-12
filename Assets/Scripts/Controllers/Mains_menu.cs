using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mains_menu : MonoBehaviour
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey("firstTime"))
        {
            // Define a chave "firstTime" para evitar que este código seja executado novamente
            PlayerPrefs.SetInt("firstTime", 1);

            // Obtém o valor atual de "maxHealth" e aumenta em 10
            int maxHealth = PlayerPrefs.GetInt("maxHealth");
            maxHealth += 10;

            // Armazena o novo valor de "maxHealth" na variável PlayerPrefs
            PlayerPrefs.SetInt("maxHealth", maxHealth);


            int EnemyDamage = PlayerPrefs.GetInt("EnemyDamage");
            EnemyDamage += 1;

            PlayerPrefs.SetInt("EnemyDamage", EnemyDamage);


            int EnemyHealth = PlayerPrefs.GetInt("EnemyHealth");
            EnemyHealth += 1;

            PlayerPrefs.SetInt("EnemyHealth", EnemyHealth);

        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(3);
    }

    public void LoadShop()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void GoInfo()
    {
        SceneManager.LoadScene(1);
 
            }
}

