using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerHealth : MonoBehaviour
{
    GameManager gm;
    LivesManager lm;
    public float currentHealth;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

        gm = FindObjectOfType<GameManager>();
        lm = FindObjectOfType<LivesManager>();
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Debug.Log("YOU DIED");
            lm.TakeLife();
            currentHealth = maxHealth;
            
        }
    }

    void TakeDamage(int amount)
    {
        currentHealth -= amount;
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
