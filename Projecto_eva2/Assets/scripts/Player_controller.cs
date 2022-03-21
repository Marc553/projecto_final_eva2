using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour
{
    //variables del player
    private float playerSpeed = 20f;
    private float speed = 40f;
    public int vida = 100;

    //sonido
    public AudioClip disparo;
    private AudioSource audioSource;
    public AudioClip muerteEnemigo;

    //variables generales
    private Rigidbody playerRigidbody;
    private Animator playerAnimator;

    //puentes de scripts
    private GameManager gameManagerScript;
    private Enemy_controller enemyScript;
    

    void Start()
    {
        //conexiones de variables
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        gameManagerScript = FindObjectOfType<GameManager>();
        enemyScript = FindObjectOfType<Enemy_controller>();
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        //conexion de los inputs
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
       
        //movimiento del personaje
        transform.Translate(Vector3.right * playerSpeed * verticalInput * Time.deltaTime);
       transform.Rotate(transform.up * speed * Time.deltaTime * horizontalInput);

        //disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerAnimator.SetTrigger("disparo");
            audioSource.PlayOneShot(disparo);
        }

        //reaccion de la vida del personaje
        if(vida <= 0)
        {
            Destroy(gameObject);
            gameManagerScript.GameOver();
        }
    }

    //colisiones con los enemigos
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("enemy2"))
        {
            vida -= 5;
            gameManagerScript.UpdateVida(vida);
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(muerteEnemigo);
        }
        
        if(collision.gameObject.CompareTag("enemy1"))
        {
            vida -= 8;
            gameManagerScript.UpdateVida(vida);
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(muerteEnemigo);
        }
    }

    //colisiones con los suministros, soportes de vida
    private void OnTriggerEnter(Collider othercollider)
    {
        if(othercollider.gameObject.CompareTag("suministros"))
        {
            vida += 5;
            gameManagerScript.UpdateVida(vida);
            Destroy(othercollider.gameObject);
        }
    }

}
