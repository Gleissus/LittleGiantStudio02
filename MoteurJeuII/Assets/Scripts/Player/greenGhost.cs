using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class greenGhost : MonoBehaviour
{
    private GameObject playerTransform;
    public float movementSpeed = 3f; // The speed at which the drone will follow the player
    public float movementSmoothing = 1f; // The amount of smoothing applied to the drone's movement
    public float floatSpeed = 0.05f; // The speed at which the drone will float up and down
    public float floatHeight = 0.5f; // The maximum height the drone will float above the player
    private float remainingTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameManager.instance.player;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the target position for the drone
        Vector3 targetPosition = playerTransform.transform.position + new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));

        // Smoothly move the drone towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, movementSmoothing * Time.deltaTime);

        // Calculate the float motion for the drone
        float floatOffset = Mathf.Cos(Time.time * floatSpeed) * floatHeight;
        Vector3 floatPosition = transform.position + new Vector3(0f, floatOffset, 0f);

        // Move the drone to the float position
        transform.position = floatPosition;

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
