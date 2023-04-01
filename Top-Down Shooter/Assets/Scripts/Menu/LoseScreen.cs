using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseScreen : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI score;

    public void Awake()
    {
        score.text = $"You got a score of {PlayerScore.Score} points";
    }
    public void Retry()
    {
        PlayerScore.Score = 0;
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
