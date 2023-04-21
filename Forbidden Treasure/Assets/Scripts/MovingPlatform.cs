using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform[] platformPos = new Transform[2];
    int direction = 1;
    public float speed;
    Vector2 target;
    
    // Update is called once per frame
    void Update()
    {
        target = currentMovementTarget();

        float distance = (target - (Vector2)platformPos[0].position).magnitude;

        if (distance <= .5f)
        {
            direction *= -1;
        }

    }

    private void FixedUpdate()
    {
        platformPos[0].position = Vector2.Lerp(platformPos[0].position, target, speed * Time.deltaTime);
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return platformPos[1].position;
        }
        else
        {
            return platformPos[2].position;
        }
    }

    private void OnDrawGizmos()
    {
        if (platformPos[0] != null && platformPos[1] != null && platformPos[2] != null)
        {
            Gizmos.DrawLine(platformPos[0].transform.position, platformPos[1].transform.position);
            Gizmos.DrawLine(platformPos[0].transform.position, platformPos[2].transform.position);
        }
    }

}
