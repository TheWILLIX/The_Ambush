using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip rocket;
    Vector3 positionPlayer;
    Player player;
    GameOver gameOverRef;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.PlayOneShot(rocket);
        player = FindObjectOfType<Player>();
        gameOverRef = FindObjectOfType<GameOver>();
        positionPlayer = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, positionPlayer, 10f * Time.deltaTime);
        if (Vector3.Distance(transform.position, positionPlayer) < 0.1f)
        {
            player.vie--;
            player.Change_Life();
            DestroyProjectile();

        }

        if (gameOverRef.gameOver == true) 
        { 
            DestroyProjectile(); 
        }
    }

    public void DestroyProjectile() 
    {         
        Destroy(gameObject);
    }
}
