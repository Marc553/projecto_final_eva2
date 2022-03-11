using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public GameObject projectilPrefab;
    
    public float cooldown = 2;
    public float nextFireTime = 0;

    void Update()
    {
        
        if(Time.time > nextFireTime)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
              Instantiate(projectilPrefab, transform.position, transform.rotation);
                nextFireTime = Time.time + cooldown;
            }

        }
        

    }


}
