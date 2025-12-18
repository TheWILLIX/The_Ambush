using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    [SerializeField]GameObject panelGameOver;
    // Start is called before the first frame update
    void Start()
    {
        panelGameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGameOver() 
    {
        panelGameOver.SetActive(true);
        
    }
}
