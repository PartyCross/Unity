using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    private float speed;

    private void Start()
    {
        speed = (Random.Range(1,4) * 10); 
    }
   
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}