using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float playerSpeed = 20f;
    public float verticalInput;
    private Rigidbody playerRigidbody;

    void Start()
    {
        
        playerRigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        playerRigidbody.AddForce(Vector3.right * playerSpeed * verticalInput);
    }
}
