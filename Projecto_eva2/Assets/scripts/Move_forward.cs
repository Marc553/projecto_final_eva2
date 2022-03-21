using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_forward : MonoBehaviour
{
    //velocidad de movimiento
    private float Speed = 20f;

    //limites de la bala
    private float limX = 38.46f;
    private float limMinusX = -38.46f;
    private float limZ = 39.548f;
    private float limMinusZ = -39.548f;

    void Update()
    {
        //Da la orden para moverse en Z

        transform.Translate(Vector3.forward * Speed * Time.deltaTime);

        //Limite del mapa 
        if (transform.position.x > limX | transform.position.z > limZ | transform.position.x < limMinusX | transform.position.z < limMinusZ)
        {
            Destroy(gameObject);
        }

    }

}
