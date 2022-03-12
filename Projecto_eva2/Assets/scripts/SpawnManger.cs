using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{/*
    public GameObject[] objectsPrefabs; 
    private Vector3 SpawnPosition;
    private int randomPosition;

    private int valor0 = 0;
    private int valor3 = 3;
    private float giro = 0;
    private float giro90 = 90;
    private float giro180 = 180;
    private float giroMenus90 = -90;
   
    private float valorPlusX = 37;
    private float valorMInusX = -37;
    private float valorPlusZ = 34.6f;
    private float valorMinusZ = -34.6f;

    private int enemiesLeft;
    private int enemiesPerWave = 1;
  

    private int randomIndex;


    void Start()
    {
        SpwamEnemyWave(enemiesPerWave);
    }

    private void Update()
    {
        enemiesLeft = FindObjectOfType<Enemy_controller>().Length;
        if(enemiesLeft <= valor0)
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
        randomPosition = Random.Range(valor0, valor3);

        if (randomPosition == valor0)
        {
             SpawnPosition = new Vector3(valorPlusX, valor0, valor0);
            Quaternion rotation = Quaternion.Euler(transform.rotation.x, giro, transform.rotation.z);
            Instantiate(objectsPrefabs[randomIndex], SpawnPosition, rotation);
        }
        if (randomPosition == 1)
        {
            SpawnPosition = new Vector3(valorMInusX, valor0, valor0);
            Quaternion rotation = Quaternion.Euler(transform.rotation.x, giro180, transform.rotation.z);
            Instantiate(objectsPrefabs[randomIndex], SpawnPosition, rotation);
        }
        if (randomPosition == 2)
        {
            SpawnPosition = new Vector3(valor0, valor0, valorPlusZ);
            Quaternion rotation = Quaternion.Euler(transform.rotation.x, giroMenus90, transform.rotation.z);
            Instantiate(objectsPrefabs[randomIndex], SpawnPosition, rotation);
        }
        if (randomPosition == valor3)
        {
            SpawnPosition = new Vector3(valor0, valor0, valorMinusZ);
            Quaternion rotation = Quaternion.Euler(transform.rotation.x, giro90, transform.rotation.z);
            Instantiate(objectsPrefabs[randomIndex], SpawnPosition, rotation);
        }
    }*/

}
