using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    PlayerHealth plyrH;

    Transform player;

    public bool isFlipped = false;

    private void Start()
    {
        plyrH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    public void Attack()
    {
        plyrH.TakeDamage(1);
    }

}
