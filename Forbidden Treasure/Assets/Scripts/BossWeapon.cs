using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
    Animator anim;

    public float attackRange = 0.5f;
    public LayerMask playerLayers;
    public Transform attackPoint;

    public int attackDamage = 1;

    public float attackRate = 1f;
    float nextAttackTime = 0f;

    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Boss").GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + 1f / attackRate;
        }

    }

    public void Attack()
    {
        // detect player in range of attack
        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);
        // damage them
        foreach (Collider2D player in hitPlayer)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(attackDamage);
        }

    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
