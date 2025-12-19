using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{

    [SerializeField] GameObject panelReload;
    // Start is called before the first frame update
    void Start()
    {
        panelReload.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayReload()
    {
        panelReload.SetActive(true);

    }

    public void StopReload()
    {
        panelReload.SetActive(false);
    }
}
