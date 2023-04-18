using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private bool isInRange = false;
    [SerializeField] private Animator animatorDoor;
    [SerializeField] private GameObject keyImage;
    [SerializeField] private GameObject doorLeft;
    [SerializeField] private GameObject doorRight;
    [SerializeField] private AudioSource openDoorSound;


    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E) && GameManager.instance.playerHasTheKey == true) // Check if the player is within range and presses the interact button (E key)
        {
            openDoorSound.Play();
            GameManager.instance.playerHasTheKey = false;
            keyImage.SetActive(false);
            animatorDoor.SetTrigger("OpenDoor");
            doorLeft.GetComponent<BoxCollider>().enabled = false;
            doorRight.GetComponent<BoxCollider>().enabled = false;
        }
    }

    // Check if the player enters the interaction range of the chest
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player is in range");
            isInRange = true;
        }
    }

    // Check if the player exits the interaction range of the chest
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Player is not in range");            
            isInRange = false;
        }
    }

}
