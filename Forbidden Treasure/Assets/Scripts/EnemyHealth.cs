using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 80;
    int currentHealth;
    private void Start()
    {
        currentHealth = maxHealth;
    }

  
    public void TakeDamage(int damage )
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        Destroy(gameObject);
    }

}
