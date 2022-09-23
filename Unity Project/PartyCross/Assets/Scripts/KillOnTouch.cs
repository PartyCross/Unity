using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
    public static event Action OnPlayerDeath;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Player>() != null)
        {
            Destroy(collision.gameObject);

            OnPlayerDeath?.Invoke();
        }
    }
}
