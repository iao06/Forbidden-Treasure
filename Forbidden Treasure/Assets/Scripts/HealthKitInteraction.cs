using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKitInteraction : MonoBehaviour
{
    PlayerHealth playerH;
    // Start is called before the first frame update
    void Start()
    {
        playerH = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>(); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerH.Heal(10);
            Destroy(gameObject);
        }
    }
}
