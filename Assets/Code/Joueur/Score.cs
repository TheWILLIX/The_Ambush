using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score = 0;
    public Text texte_score;

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
}
