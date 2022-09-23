using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
      
public class PlayerHealth : MonoBehaviour {

    [SerializeField] float health = 10;
    public static event Action OnPlayerDeath;
    
    public void decreaseHealth(float amount){
        health -= amount;
        if ( health <= 0 ) {
            health = 0;
            Destroy(gameObject);
            OnPlayerDeath?.Invoke();
        }
    }
}
