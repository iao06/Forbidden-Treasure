using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteraction : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreTextScipt.coinAmount += 1;
        Destroy(gameObject);
    }
}
