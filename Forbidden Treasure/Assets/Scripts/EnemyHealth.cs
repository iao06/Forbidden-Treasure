using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Death();
        }
    }

    public void TakeDamage()
    {
        Health--;
    }

    public void Death()
    {
        Destroy(gameObject);
    }

}
