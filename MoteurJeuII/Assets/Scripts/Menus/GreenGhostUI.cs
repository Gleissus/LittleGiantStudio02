using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenGhostUI : MonoBehaviour
{
    [SerializeField] GameObject image;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.playerGreenGhost == true)
        {
            image.SetActive(false);
        }
        
    }
}
