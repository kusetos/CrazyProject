using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoUp : MonoBehaviour
{
    
    void Start()
    {
        
        
    }

    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime;
             
    }
}
