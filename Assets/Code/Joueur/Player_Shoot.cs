using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Shoot : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000f))
        {
            if (hit.collider.TryGetComponent(out Enemy enemy))
            {
                enemy.TakeDamage(1f);
            }
        }
    }
}
