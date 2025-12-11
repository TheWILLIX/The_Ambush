using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health = 3f;

    public void TakeDamage(float damage)
    {
        health -= damage;

        Debug.Log("Enemy touched! Health = " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
