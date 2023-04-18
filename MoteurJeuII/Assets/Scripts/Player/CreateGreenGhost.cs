using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreateGreenGhost : MonoBehaviour
{
    [Header("Playr Information")]
    public Transform playerTransform;
    [Header("Green Ghost Variables")]
    public GameObject ghostGreenPrefab;
    public GameObject spawnPoint;
    public float duration = 5f;
    public float heightInvoke = 5f;

    private GameObject droneInstance;

    [Header("Audio")]
    [SerializeField] private AudioSource useSkillSound;

    private void Start()
    {
        playerTransform = transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2) && GameManager.instance.playerGreenGhost == true)
        {
            Debug.Log("player uses greenGhost");
            useSkillSound.Play();
            CreateGreenGhostCopy();
        }
    }

    private void CreateGreenGhostCopy()
    {
        // Create a new drone object and set its position to follow the player     
        droneInstance = Instantiate(ghostGreenPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation);
        //droneInstance.transform.parent = playerTransform;
        
    }
}
