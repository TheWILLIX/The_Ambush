using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Player : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip Shoot_pistol_sound;
    public AudioClip Out_of_Ammo_sound;
    public AudioClip reload_pistol_sound;
    public Camera cam;
    public int bullets = 6;
    public int vie = 4;
    public UnityEngine.UI.Text Nb_Munition;
    public UnityEngine.UI.Text Nb_Vie;
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
            else
            {
                audioSource.PlayOneShot(Out_of_Ammo_sound);
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
            audioSource.PlayOneShot(Shoot_pistol_sound);

            bullets--;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.collider.TryGetComponent(out Enemy enemy))
                {
                    enemy.TakeDamage(1);
                }
                if (hit.collider.TryGetComponent(out Heal heal))
                {
                    heal.TakeDamage(1);
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
        audioSource.PlayOneShot(reload_pistol_sound);

        bullets = 6;
        Nb_Munition.text = "Munition : " + bullets;
        FindObjectOfType<Reload>().StopReload();
    }

    public void Change_Life()
    {
        Nb_Vie.text = "Vie : " + vie;
        if (vie <= 0)
        {
            FindObjectOfType<GameOver>().PlayGameOver();
            gameOver = true;

        }
    }
}