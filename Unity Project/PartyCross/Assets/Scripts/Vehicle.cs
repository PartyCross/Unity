using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private float speed; 
   
    private void Start()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}