using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;

    public int waveNumber = 1;
    public float timeBetweenWaves = 3f;

    private bool waveInProgress = false;

    void Update()
    {
        // Si une vague n'est pas en cours ET qu'il ne reste aucun ennemi dans la scène
        if (!waveInProgress && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            StartCoroutine(StartNextWave());
        }
    }

    IEnumerator StartNextWave()
    {
        waveInProgress = true;

        Debug.Log("Vague " + waveNumber + " commence dans " + timeBetweenWaves + " secondes.");
        yield return new WaitForSeconds(timeBetweenWaves);

        int enemyCount = waveNumber * 3;

        for (int i = 0; i < enemyCount; i++)
        {
            Transform spawn = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, spawn.position, spawn.rotation);
            yield return new WaitForSeconds(0.3f);
        }

        waveNumber++;
        waveInProgress = false;
    }
}