using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Enemy : MonoBehaviour
{
    public int health;
    public Player playerRef;
    WaitForSeconds timer;

    public void Start()
    {
        playerRef = FindObjectOfType<Player>();
        StartCoroutine(TireSurJoueur());
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
       yield return new WaitForSeconds(3);
        playerRef.vie--;
        FindObjectOfType<Player>().Change_Life();
    }
}
