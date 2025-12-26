using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject healPrefab;
    public List<Transform> spawnPoints;
    public List<Transform> spawnPointsUsed;

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
        for (int i = 0; i < spawnPoints.Count; i++)
        {
            spawnPointsUsed.Add(null);
        }
        waveInProgress = true;

        Debug.Log("Vague " + waveNumber + " commence dans " + timeBetweenWaves + " secondes.");
        yield return new WaitForSeconds(timeBetweenWaves);

        int enemyCount = waveNumber;

        // temporaire à modifier
        if (enemyCount > 10) { enemyCount = 10; }


        for (int i = 0; i < enemyCount; i++)
        {

            int random_id = UnityEngine.Random.Range(0, spawnPoints.Count);
            Transform spawn = spawnPoints[random_id];

            spawnPoints.RemoveAt(random_id);
            spawnPointsUsed[i] = spawn;
            int random_heal = UnityEngine.Random.Range(0, 5);
            if (random_heal == 0)
            {
                Instantiate(healPrefab, spawn.position, spawn.rotation);
            }
            else 
            { 
                Instantiate(enemyPrefab, spawn.position, spawn.rotation);
            }
            yield return new WaitForSeconds(0.4f);
        }


        for (int i = spawnPointsUsed.Count - 1; i > -1; i--)
        {
            if (spawnPointsUsed[i] != null) 
            { 
                spawnPoints.Add(spawnPointsUsed[i]);
            }
            spawnPointsUsed.RemoveAt(i);
        }

        waveNumber++;
        waveInProgress = false;
    }

}