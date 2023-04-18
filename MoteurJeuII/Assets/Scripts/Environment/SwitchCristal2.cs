using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCristal2 : MonoBehaviour
{
    private bool isInRange = false;

    [SerializeField] private GameObject cristal2;
    [SerializeField] private RedMagicDoor redMagicDoor;
    [SerializeField] private AudioSource crystalActiveSound;

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E)) // Check if the player is within range and presses the interact button (E key)
        {
            Debug.Log("Player Active Cristal2");
            crystalActiveSound.Play();
            cristal2.GetComponent<Light>().enabled = true;
            redMagicDoor.crystal2 = true;
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
