using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Retry : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RetryGame()
    {
        //UnityEngine.SceneManagement.SceneManager.UnloadScene("Map");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
        
        Debug.Log("Retry");
    }
}
