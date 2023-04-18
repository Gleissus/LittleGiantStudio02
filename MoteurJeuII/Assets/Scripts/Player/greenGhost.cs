using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenGhost : MonoBehaviour
{
    private GameObject playerTransform;
    public float movementSpeed = 0.1f; // The speed at which the drone will follow the player
    
    private float remainingTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameManager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = transform.position;
        Vector3 b = playerTransform.transform.position;

        transform.position = Vector3.Lerp(a, b, movementSpeed);
    

        // Check if the drone is active
        if (remainingTime > 0f)
        {
            // Decrement the remaining active time
            remainingTime -= Time.deltaTime;

            // Check if the remaining active time has expired
            if (remainingTime <= 0f)
            {
                // Destroy the drone object
                Destroy(this);
            }
        }
    }
}
