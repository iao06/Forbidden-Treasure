using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 400;
    int currentHealth;

    Animator anim;
    private void Start()
    {
        currentHealth = maxHealth;
        anim = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth < 280)
        {
            GetComponent<Animator>().SetBool("isPhase2", true);
        }

        if (currentHealth < 160)
        {
            GetComponent<Animator>().SetBool("isPhase3", true);
        }

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        transform.Rotate(0f, 0f, 0f);
        anim.SetBool("isDead", true);
    }
}
