using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject[] objectsPrefabs; 
    public GameObject[] way_points; 
    public GameObject[] particle_points; 
    private GameObject SpawnPosition;
    private GameObject SpawnParticle;
  
    private int enemiesLeft;
    private int enemiesPerWave = 1;
  
    private int randomIndex;
    private int randomPosition;
    private int randomParticle;

    public ParticleSystem warning;

    void Start()
    {
        SpwamEnemyWave(enemiesPerWave);
    }

    private void Update()
    {
        enemiesLeft = FindObjectsOfType<Enemy_controller>().Length;
        if(enemiesLeft <= 0)
        {
            enemiesPerWave++;
            SpwamEnemyWave(enemiesPerWave);

        }
    }

    private void SpwamEnemyWave(int totalenemies)
    {
        for(int i = 0; i < totalenemies; i++)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        randomIndex = Random.Range(0, objectsPrefabs.Length);
        randomPosition = Random.Range(0, way_points.Length);
        

        SpawnPosition = way_points[randomPosition];
        SpawnParticle = particle_points[randomPosition];
        Instantiate(objectsPrefabs[randomIndex], SpawnPosition.transform.position, SpawnPosition.transform.rotation);
        Instantiate(warning, SpawnParticle.transform.position, SpawnParticle.transform.rotation);

        
    }

}
