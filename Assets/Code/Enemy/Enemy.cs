using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    public float health = 3f;
    public Player player;
    WaitForSeconds timer;

    public void Start()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(TireSurJoueur());
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        Debug.Log("Enemy touched! Health = " + health);

        if (health <= 0)
        {
            FindObjectOfType<Score>().AddScore(10);
            Destroy(gameObject);
        }
    }

    public IEnumerator TireSurJoueur() 
    {
       yield return new WaitForSeconds(4);
        player.vie--;
        Debug.Log("Vie Joueur : " + player.vie);
    }
}
