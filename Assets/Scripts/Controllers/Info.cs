using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Info : MonoBehaviour
{
    // Start is called before the first frame update

    public void GoTwitch()
    {
        Application.OpenURL("https://www.twitch.tv/playoff23");
    }

    public void goInstagram()
    {
        Application.OpenURL("https://www.instagram.com/playoff231/");
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
        
    
}
