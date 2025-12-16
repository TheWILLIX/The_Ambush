using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public Camera cam;
    public int bullets = 6;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (bullets > 0)
            {
                Shoot();
            }
        }
        if (Input.GetKeyDown("r"))
        {
            Realod();
        }
    }

    void Shoot()
    {
        bullets--;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            if (hit.collider.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(1f);
            }
        }
        Debug.Log(bullets);
    }

    void Realod() 
    {
        bullets = 6;
        Debug.Log(bullets);
    }
}
