using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obelisk_GreenGhostSkill : MonoBehaviour
{

    private bool isInRange = false;
  

    [SerializeField] private AudioSource getItem;
    [SerializeField] private GameObject obeliskLight;



    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.E)) // Check if the player is within range and presses the interact button (E key)
        {
            getItem.Play();     
            GameManager.instance.playerGreenGhost = true;
            obeliskLight.SetActive(false);
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
