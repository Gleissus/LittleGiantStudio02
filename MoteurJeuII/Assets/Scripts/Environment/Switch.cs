using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [Header("Plataform GameObject")]
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private Transform pointC;
    [SerializeField] private Transform platformA;
    [SerializeField] private Transform platformB;
    [SerializeField] private Transform platformC;
    [Header("Plataform Variables")]
    [SerializeField] private float speedPlatform = 2f;
    [SerializeField] private bool switchOn = false;
    [Header("Crystal Variables")]
    [SerializeField] private GameObject cristal1;
    [SerializeField] private AudioSource crystalActiveSound;


    private bool isInRange = false;


    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E)) // Check if the player is within range and presses the interact button (E key)
        {
            Debug.Log("Player Active the Switch");
            crystalActiveSound.Play();
            cristal1.GetComponent<Light>().enabled = true;
            switchOn = true;
        }

        if (switchOn == true)
        {
            platformA.position = Vector3.MoveTowards(platformA.position, pointA.position, (Time.deltaTime * speedPlatform));            
            platformB.position = Vector3.MoveTowards(platformB.position, pointB.position, (Time.deltaTime * speedPlatform));            
            platformC.position = Vector3.MoveTowards(platformC.position, pointC.position, (Time.deltaTime * speedPlatform));            
            
        }        
    }


    // Check if the player enters the interaction range of the button
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerGhostBlue"))
        {            
            Debug.Log("Player is in range");
            isInRange = true;
        }
    }

    // Check if the player exits the interaction range of the button
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerGhostBlue"))
        {
            Debug.Log("Player is not in range");
            isInRange = false;
        }
    }
}
