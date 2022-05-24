using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int score;
    int health;
    int ammo;

    [SerializeField] TextMeshProUGUI AmmoText;
    [SerializeField]TextMeshProUGUI scoreText;
    [SerializeField] Canvas gameOverCanvas;
    public Ammo ammO;


    public void IncreaseScore(int _score)
    {
        
        score += _score;
    }

    public void Update()
    {
        scoreText.text = "Score: " + score;
        AmmoText.text = "Ammo:" + ammO.GetCurrentAmmo();
        if (score >= 50)
            EndGame();
    }

    public void EndGame()
    {
        gameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
    }
}
