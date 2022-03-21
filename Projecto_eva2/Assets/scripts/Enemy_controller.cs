using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{
    //variable velocidad
    private float speed = 2f;

    //variables generales
    private Rigidbody enemyRigidbody;
    private GameObject player;
    
    //audio manager
    public AudioClip muerteEnemigo;
    public AudioSource audioSource;
    
    //variables varias
    private int playerLeft;
    public GameManager gameManagerScript;

    void Start()
    {
        //conexiones
        audioSource = GetComponent<AudioSource>();
        enemyRigidbody = GetComponent<Rigidbody>();
        gameManagerScript = FindObjectOfType<GameManager>();
        
        //logica de busqueda del player
        if(!gameManagerScript.isGameOver)
        {
            player = GameObject.Find("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //logica segimiento
        if (!gameManagerScript.isGameOver)
        { 
            Vector3 direction = (player.transform.position - transform.position).normalized;
             enemyRigidbody.AddForce(direction * speed);
        }
    }

    //interaccion con projectil
    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Projectil"))
        {
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);
            audioSource.PlayOneShot(muerteEnemigo);
        }
    }
}
