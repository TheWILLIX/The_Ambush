using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float health = 3f;

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
}
