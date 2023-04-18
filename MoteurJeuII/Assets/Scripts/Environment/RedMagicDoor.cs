using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMagicDoor : MonoBehaviour
{

    public bool crystal1 = false;
    public bool crystal2 = false;

    [SerializeField] AudioSource magicGateOpen;


    // Update is called once per frame
    void Update()
    {
        if(crystal1 == true && crystal2 == true)
        {
            magicGateOpen.Play();
            Color32 rgbColor = new Color32(0, 180, 255, 100);
            GetComponent<Renderer>().material.color = rgbColor;
            GetComponent<Light>().color = rgbColor;
            GetComponent<BoxCollider>().enabled = false;
        }        
    }
}
