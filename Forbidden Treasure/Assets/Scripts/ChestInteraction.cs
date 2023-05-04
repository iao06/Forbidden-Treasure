
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class ChestInteraction : MonoBehaviour
{
    public bool chestInteract;
    Animator animr;
    // Start is called before the first frame update
    void Start()
    {
        animr = gameObject.GetComponent<Animator>();
        chestInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (chestInteract == true)
        {
            animr.SetBool("chestInteracted", true);
        }
        
        if (chestInteract == false)
        {
            animr.SetBool("chestInteracted", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision && !chestInteract)
        {
            chestInteract = true;
            ScoreTextScipt.coinAmount += 50;
        }
    }
}
