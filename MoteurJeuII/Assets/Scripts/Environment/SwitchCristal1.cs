using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCristal1 : MonoBehaviour
{
    private bool isInRange = false;

    [SerializeField] private GameObject cristal1;
    [SerializeField] private RedMagicDoor redMagicDoor;
    [SerializeField] private AudioSource crystalActiveSound;


    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E)) // Check if the player is within range and presses the interact button (E key)
        {
            Debug.Log("Player Active Cristal1");
            crystalActiveSound.Play();
            cristal1.GetComponent<Light>().enabled = true;
            redMagicDoor.crystal1 = true;
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
