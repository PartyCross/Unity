using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plank : MonoBehaviour
{
    private float speed;
    public bool isLog = true;

    private void Start()
    {
        speed = (Random.Range(1,2) * 10);
    }
    
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
