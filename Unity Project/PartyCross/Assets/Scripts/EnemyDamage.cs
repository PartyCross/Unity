using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] float damage = 10;

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.name == "Player") {
            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            health.decreaseHealth(damage);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.name == "Player") {
            PlayerHealth health = other.gameObject.GetComponent<PlayerHealth>();
            health.decreaseHealth(damage);
        }
    }

}