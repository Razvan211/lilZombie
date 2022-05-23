using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMenu : MonoBehaviour
{
    

    public void StartGame()
    {

        SceneManager.LoadScene("SampleScene");
    }
}
