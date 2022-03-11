using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float playerSpeed = 20f;
    public float speed = 20f;
    
    private Rigidbody playerRigidbody;

    void Start()
    {
        
        playerRigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        playerRigidbody.AddForce(transform.right * playerSpeed * verticalInput);
        
        float horizontalInput = Input.GetAxis("Horizontal");
       transform.Rotate(Vector3.up * speed * Time.deltaTime * horizontalInput);

    }
}
