using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 positionPlayer;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
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
    }

    public void DestroyProjectile() 
    {         
        Destroy(gameObject);
    }
}
