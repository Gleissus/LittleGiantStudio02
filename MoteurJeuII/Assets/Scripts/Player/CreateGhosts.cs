using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGhosts : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject ghostBluePrefab;   

    [SerializeField] private AudioSource useSkillSound;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            useSkillSound.Play();
            CreateBlueGhostCopy();
        }
    }

    void CreateBlueGhostCopy()
    {
        if (playerPrefab == null || ghostBluePrefab == null)
        {
            Debug.LogWarning("Player or Ghost prefab is not assigned.");
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("Player not found in scene.");
            return;
        }

        GameObject copy = Instantiate(ghostBluePrefab, player.transform.position, player.transform.rotation);
        //copy.GetComponent<GhostController>().enabled = true;
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<CreateGhosts>().enabled = false;
    }
}
