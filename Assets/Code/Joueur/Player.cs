using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Camera cam;
    public int bullets = 6;
    public int vie = 4;
    public Text Nb_Munition;
    public Text Nb_Vie;
    public bool gameOver = false;

    private void Start()
    {
        Nb_Munition.text = "Munition : " + bullets;
        Change_Life();
    }

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
        if (gameOver == false)
        {
            bullets--;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.collider.TryGetComponent(out Enemy enemy))
                {
                    enemy.TakeDamage(1);
                }
                if (hit.collider.TryGetComponent(out Projectile projectile))
                {
                    projectile.DestroyProjectile();
                }
            }
            Nb_Munition.text = "Munition : " + bullets;

            if (bullets <= 0)
            {
                FindObjectOfType<Reload>().PlayReload();
            }
        }
    }

    void Realod() 
    {
        bullets = 6;
        Nb_Munition.text = "Munition : " + bullets;
        FindObjectOfType<Reload>().StopReload();
    }

    public void Change_Life() 
    {
        Nb_Vie.text = "Vie : " + vie;
        Debug.Log(vie);
        if (vie <= 0) 
        {
            FindObjectOfType<GameOver>().PlayGameOver();
            gameOver = true;
            
        }
    }
}
