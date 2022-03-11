using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_forward : MonoBehaviour
{
    //La velocidad que alcanzará 
    public float Speed = 5f;
    public float limX = 38.46f;
    public float limMinusX = -38.46f;
    
    public float limZ = 39.548f;
    public float limMinusZ = -39.548f;


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
