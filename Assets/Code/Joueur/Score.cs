using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text texte_score;
    public Text scoreFinal;
    public Text meilleurScore;

    public void Start()
    {
        texte_score.text = "SCORE : " + score;
    }

    public void AddScore(int amount)
    {
        score += amount;
        //Debug.Log("Score: " + score);
        texte_score.text = "SCORE : " + score;
    }

    public void ShowScoreFinal()
    {
        scoreFinal.text = "SCORE : " + score;
        SaveScore();
        meilleurScore.text = "Meilleur Score : " + PlayerPrefs.GetInt("BestScore", 0);
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("LastScore", score);
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
    }
}
