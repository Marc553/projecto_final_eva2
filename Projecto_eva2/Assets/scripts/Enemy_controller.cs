using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{
    private Rigidbody enemyRigidbody;
    private GameObject player;
    [SerializeField] private float speed = 5f;
    private int limY = -3;
    private int playerLeft;
    public GameManager gameManagerScript;


    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();

        gameManagerScript = FindObjectOfType<GameManager>();
        
        if(!gameManagerScript.isGameOver)
        {
            player = GameObject.Find("Player");
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManagerScript.isGameOver)
        { 
            Vector3 direction = (player.transform.position - transform.position).normalized;
             enemyRigidbody.AddForce(direction * speed);
        }
           

        if(transform.position.y <= limY)
        {
            Destroy(gameObject);
        }

        

    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Projectil"))
        {
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);
        }
    }

}
