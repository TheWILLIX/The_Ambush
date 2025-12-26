using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public int health;
    public Player playerRef;
    WaitForSeconds timer;
    public GameObject projectilePrefab;

    public void Start()
    {
        playerRef = FindObjectOfType<Player>();
        StartCoroutine(TireSurJoueur());
        transform.rotation = Quaternion.LookRotation(playerRef.transform.position - transform.position);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        

        if (health <= 0)
        {
            FindObjectOfType<Score>().AddScore(10);
            Destroy(gameObject);
        }
    }

    public IEnumerator TireSurJoueur() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(3);
            Instantiate(projectilePrefab, transform.position, transform.rotation);
        }
        
    }
}
