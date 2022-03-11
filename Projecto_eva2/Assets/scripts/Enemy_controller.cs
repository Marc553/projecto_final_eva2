using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_controller : MonoBehaviour
{
    private Rigidbody enemyRigidbody;
    public GameObject player;
    [SerializeField] private float speed = 5f;
    

    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        enemyRigidbody.AddForce(direction * speed);
    }
}
