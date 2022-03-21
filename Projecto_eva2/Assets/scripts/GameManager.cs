using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //arrays de elementos/elementos exteriores
    public GameObject[] objectsPrefabs;
    public GameObject powerUpPrefab;
    public GameObject[] way_points;
    public GameObject[] particle_points;
    public ParticleSystem warning;
    
    //elementos randoms 
    private GameObject SpawnPosition;
    private GameObject SpawnParticle;
    private int randomEnemy;
    private int randomPosition;
    private int randomParticle;
    private float spawnPositionRange = 30;
    private Player_controller playerScript;
    private int vida;

    //spawn oleadas de enemigos
    private int enemiesLeft;
    private int enemiesPerWave = 1;

    //audio elements
    private AudioSource audioSource;
    public AudioClip menu;
    public AudioClip juego;
    public AudioClip muerte;

    //Game Manager 
    public GameObject gameOverPanel;
    public GameObject mainMenuPanel;
    public bool isGameOver = true;
    public TextMeshProUGUI vidaX;

    void Start()
    { 
        //conexion de elementos
        audioSource = GetComponent<AudioSource>();
        playerScript = FindObjectOfType<Player_controller>();
        
        //comienzo del juego, abrir el menu para el reseteo y activar el game over
        isGameOver = true;
        mainMenuPanel.SetActive(true);
        
        //loop de la musica del menu
        audioSource.clip = menu;
        audioSource.loop = true;
        audioSource.Play();
    }

    private void Update()
    {
        if(!isGameOver)
        {
            //busqueda de la cantidad de enemigos
            enemiesLeft = FindObjectsOfType<Enemy_controller>().Length;

            //logica de oleada de enemigos
            if (enemiesLeft <= 0)
            {
             enemiesPerWave++;
             SpwamEnemyWave(enemiesPerWave);
             Instantiate(powerUpPrefab, RandomSpawnPostion(), powerUpPrefab.transform.rotation);
            }
        }      
    }

    //elementos de la oleada
    private void SpwamEnemyWave(int totalenemies)
    { 
       for (int i = 0; i < totalenemies; i++)
       {
         SpawnEnemy();
       }
    }

    //logica de spawn de enemigos
    public void SpawnEnemy()
    {
        //creacion de elementos randoms para la posicion de spawn
        randomEnemy = Random.Range(0, objectsPrefabs.Length);
         randomPosition = Random.Range(0, way_points.Length);
         SpawnPosition = way_points[randomPosition];
         SpawnParticle = particle_points[randomPosition];
      
        //instanciacion del enemigo y las particulas en el lugar de aparicion del mismo
        Instantiate(objectsPrefabs[randomEnemy], SpawnPosition.transform.position, SpawnPosition.transform.rotation);
        Instantiate(warning, SpawnParticle.transform.position, SpawnParticle.transform.rotation);   
    }

    //posicion random del powerup
    public Vector3 RandomSpawnPostion()
    {
        float xRandom = Random.Range(-spawnPositionRange, spawnPositionRange);
        float zRandom = Random.Range(-spawnPositionRange, spawnPositionRange);

        return new Vector3(xRandom, 0, zRandom);
    }

    //vida
    public void UpdateVida(int vidaNum)
    {
        vida = vidaNum;
        vidaX.text = $"Vida: {vida}";
    }

    //funcion del game over
    public void GameOver()
    {
        audioSource.Stop();
        isGameOver = true;
        gameOverPanel.SetActive(true);
        audioSource.PlayOneShot(muerte);
    }

    //RESTART GAME
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    //START GAME
    public void StartGame()
    {
        //configuracion del sonido
        audioSource.Stop();
        audioSource.clip = juego;
        audioSource.loop = true;
        audioSource.Play();

        //configuracion de las pantallas
        mainMenuPanel.SetActive(false);
        isGameOver = false;
        gameOverPanel.SetActive(false);
        
        UpdateVida(100);
        
        //inicio del spawn enemy
        SpwamEnemyWave(enemiesPerWave);
        enemiesPerWave = 1;
    }

    //EXIT
    public void Exit()
    {
        #if UNITY_EDITOR
    
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
