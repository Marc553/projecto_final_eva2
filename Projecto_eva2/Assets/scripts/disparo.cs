using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    //objeto de projectil
    public GameObject projectilPrefab;
    
    //variables coldown
    public float cooldown = 2;
    public float nextFireTime = 0;
    
    void Update()
    {
        //logica coldown
        if(Time.time > nextFireTime)
        { 
            //disparo
            if (Input.GetKeyDown(KeyCode.Space))
            {
              Instantiate(projectilPrefab, transform.position, transform.rotation);
                nextFireTime = Time.time + cooldown;
            }
        }
    }
}
