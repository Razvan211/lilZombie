using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    int score;

    [SerializeField]TextMeshProUGUI scoreText;
    [SerializeField] Canvas gameOverCanvas;


    public void IncreaseScore(int _score)
    {
        score += _score;
    }

    public void Update()
    {
        scoreText.text = "Score: " + score;

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
