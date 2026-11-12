using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TPController : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LoadNexLevel();
            int EnemyDamage = PlayerPrefs.GetInt("EnemyDamage");
            EnemyDamage += 1;
            Debug.Log(EnemyDamage);

            PlayerPrefs.SetInt("EnemyDamage", EnemyDamage);

            int EnemyHealth = PlayerPrefs.GetInt("EnemyHealth");
            EnemyHealth += 2;

            PlayerPrefs.SetInt("EnemyHealth", EnemyHealth);
        }
    }

    public void LoadNexLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
