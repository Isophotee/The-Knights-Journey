using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKillHazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            PlayerHealth playerHealth = col.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.InstaKill(); // Call the InstaKill method
            }
        }
    }
}
