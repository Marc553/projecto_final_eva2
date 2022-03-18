using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    public float playerSpeed = 20f;
    public float speed = 20f;
    
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;

    public int vida = 200;

    void Start()
    {
        
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    
    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        //playerRigidbody.AddForce(transform.right * playerSpeed * verticalInput);
        transform.Translate(Vector3.right * playerSpeed * verticalInput * Time.deltaTime);

        float horizontalInput = Input.GetAxis("Horizontal");
       transform.Rotate(transform.up * speed * Time.deltaTime * horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("disparo");
        }

        if(vida <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy_easy"))
        {
            vida -= 10;
            Destroy(collision.gameObject);
        }
        
        if(collision.gameObject.CompareTag("enemy_medium"))
        {
            vida -= 15;
            Destroy(collision.gameObject);
        }
        
        if(collision.gameObject.CompareTag("enemy_hard"))
        {
            vida -= 20;
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerEnter(Collider othercollider)
    {
        if(othercollider.gameObject.CompareTag("suministros"))
        {
            vida += 25;
            Debug.Log($"{vida}");
            Destroy(othercollider.gameObject);
        }
    }

}
