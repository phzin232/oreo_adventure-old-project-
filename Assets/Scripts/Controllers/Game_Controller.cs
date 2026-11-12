using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Color = UnityEngine.Color;

public class Game_Controller : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    public int coins;
    public TextMeshProUGUI coinsText;

    public TextMeshProUGUI tutorialFade;

    public GameObject healthMax;
    public GameObject pauseObj;
    public GameObject Gameoverobj;
    public GameObject PlayerDeath;

    public int totalcoins;

    private bool isPaused;

    public float duration = 2f; // duração em segundos para o objeto desaparecer
    public float minAlpha = 0f; // transparência mínima
    public float maxAlpha = 1f; // transparência máxima

    public float delayInSeconds = 2f;

    // public TextMeshProUGUI HeathMaxFade;

    public static Game_Controller instance;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;

    }

    private void Start()
    {
        StartCoroutine(FadeOutText(10.0f));
        totalcoins = (PlayerPrefs.GetInt("coins"));
        // Encontre o componente MeshRenderer do objeto
        //HeathMaxFade = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        pauseGame();
    }

    public void UpdateLives(int value)
    {

        healthText.text = value.ToString();
    }

    public void UpdateCoins(int value)
    {
        coins += value;
        coinsText.text = coins.ToString();

        PlayerPrefs.SetInt("coins", coins + totalcoins);
    }

    public void pauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseObj.SetActive(isPaused);

        }
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void HealthMax()
    {
        healthMax.SetActive(true);

        Invoke("DisableObject", delayInSeconds);
    }

    private void DisableObject()
    {
        healthMax.SetActive(false);
    }

    public void GameOver()
    {
        Gameoverobj.SetActive(true);
        PlayerDeath.SetActive(false);
    }

    public void RestartGame()
    {
        //mudar cena
        SceneManager.LoadScene(3);
        
        
        int EnemyDamage = PlayerPrefs.GetInt("EnemyDamage");
        EnemyDamage = 1;

        PlayerPrefs.SetInt("EnemyDamage", EnemyDamage);

        int EnemyHealth = PlayerPrefs.GetInt("EnemyHealth");
        EnemyHealth = 1;

        PlayerPrefs.SetInt("EnemyHealth", EnemyHealth);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
    //Fade out tutorial
    IEnumerator FadeOutText(float fadeDuration)
    {
        // Obtenha a cor atual do texto
        Color originalColor = tutorialFade.color;

        // Defina a opacidade inicial para 1 (texto totalmente visível)
        float alpha = 1.0f;

        // Repita até que a opacidade seja menor ou igual a zero
        while (alpha > 0.0f)
        {
            // Diminua gradualmente a opacidade
            alpha -= Time.deltaTime / fadeDuration;

            // Crie uma nova cor com a mesma cor original, mas com a opacidade atualizada
            Color newColor = new UnityEngine.Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            // Atualize a cor do TextMeshPro com a nova cor
            tutorialFade.color = newColor;

            // Espere até o próximo quadro antes de continuar
            yield return null;
        }

        // Defina a cor final para totalmente transparente
        tutorialFade.color = new UnityEngine.Color(originalColor.r, originalColor.g, originalColor.b, 0.0f);
    }


}
