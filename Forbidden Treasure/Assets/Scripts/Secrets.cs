using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secrets : MonoBehaviour
{
    public void SecretFound()
    {
        Destroy(gameObject);
    }
}
