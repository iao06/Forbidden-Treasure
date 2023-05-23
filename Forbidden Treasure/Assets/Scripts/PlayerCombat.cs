using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator anim;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public LayerMask bossLayers;
    public LayerMask secretLayers;

    public int attackDamage = 40;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // attack
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

    }

    public void Attack()
    {
        // play an attack anim
        anim.SetTrigger("Attack");
        // detect enemies in range of attack
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        Collider2D[] hitBosses = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bossLayers);
        Collider2D[] hitSecrets = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, secretLayers);
        // damage them
        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }

        foreach(Collider2D boss in hitBosses)
        {
            boss.GetComponent<BossHealth>().TakeDamage(attackDamage);
        }

        foreach(Collider2D secret in hitSecrets)
        {
            secret.GetComponent<Secrets>().SecretFound();
        }
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
