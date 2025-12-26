using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    [SerializeField]GameObject panelGameOver;
    [SerializeField] GameObject panelUI;
    Score gameOverScore;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        panelGameOver.SetActive(false);
        gameOverScore = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGameOver() 
    {
        panelGameOver.SetActive(true);
        gameOver = true;
        gameOverScore.ShowScoreFinal();
        Cursor.visible = true;
        Viseur viseur = FindObjectOfType<Viseur>();
        viseur.gameObject.SetActive(false);
        panelUI.SetActive(false);

    }
}
