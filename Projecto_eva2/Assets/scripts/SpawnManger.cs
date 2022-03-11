using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject[] objectsPrefabs; 
    private Vector3 SpawnPosition;

    private int valor0 = 0;
    private int valor5 = 5;
    private float giro = 0;
    private float giro90 = 90;
    private float giro180 = 180;
    private float giro270 = 270;
    private float giro360 = 360;
    private float valorPlusX = 37;
    private float valorMInusX = -37;
    private float valorPlusZ = 34.6f;
    private float valorMinusZ = -34.6f;

    private float startTime = 2;
    private float repeatRate = 1.5f;

    private int randomIndex;


    void Start()
    {
        InvokeRepeating("SpawnObject", startTime, repeatRate);
    }
    public Vector3 RandomSpawnPosition()
    {

        return new Vector3(valorPlusX, 0, valorPlusZ);
    }

    public void SpawnObject()
    {
        randomIndex = Random.Range(0, objectsPrefabs.Length);
        Quaternion rotation = Quaternion.Euler(transform.rotation.x, giro, transform.rotation.z);
        Instantiate(objectsPrefabs[randomIndex],SpawnPosition, rotation);
    }

}
