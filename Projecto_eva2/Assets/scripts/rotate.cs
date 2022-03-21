using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    //velocidad de rotacion
    private float spinSpeed;

    void Update()
    {
        //rotacion
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
