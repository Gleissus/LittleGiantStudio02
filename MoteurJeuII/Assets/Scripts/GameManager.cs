using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public void Awake()
    {
        instance = this;
    }

    public GameObject player;
    public bool playerHasTheKey = false;
    public bool playerGreenGhost = false;
}