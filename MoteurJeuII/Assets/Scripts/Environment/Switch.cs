using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [Header("Plataform GameObject")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform platform;
    [Header("Plataform Variables")]
    [SerializeField] private float speedPlatform = 2f;
    [SerializeField] private bool switchOn = false;
    [SerializeField] private Animator animatorSwitch;
   
    private bool isInRange = false;


    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E)) // Check if the player is within range and presses the interact button (E key)
        {
            Debug.Log("Player Active the Switch");
            switchOn = true;
        }

        if (switchOn == true)
        {
            platform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.PingPong(Time.time * speedPlatform, 1));            
            animatorSwitch.SetTrigger("SwichtOn");
        }        
    }


    // Check if the player enters the interaction range of the button
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is in range");
            isInRange = true;
        }
    }

    // Check if the player exits the interaction range of the button
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player is not in range");
            isInRange = false;
        }
    }
}
