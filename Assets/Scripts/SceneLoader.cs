using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
    public void ReloadGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
        
    }
    public void QuitGame()
    {
        Application.Quit();
        Time.timeScale = 1;
    }
}
