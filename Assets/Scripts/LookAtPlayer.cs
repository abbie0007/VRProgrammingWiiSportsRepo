using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction towards the player
            Vector3 direction = player.position - transform.position;
            direction.y = 0;
            Quaternion rotation = Quaternion.LookRotation(direction);

            // Apply the rotation but keep the object upright by forcing its local rotation to 90 degrees on the X axis
            transform.rotation = Quaternion.Euler(90, rotation.eulerAngles.y, 0);
        }
    }
}