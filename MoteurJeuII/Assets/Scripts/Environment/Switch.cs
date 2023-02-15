using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform platform;

    [SerializeField] private float speedPlatform = 2f;
    [SerializeField] private bool switchOn = false;
    [SerializeField] private Animator animatorSwitch;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (switchOn == true)
        {
            platform.position = Vector3.Lerp(pointA.position, pointB.position, Mathf.PingPong(Time.time * speedPlatform, 1));
            //animatorSwitch.Play("SwitchOn");
            animatorSwitch.SetTrigger("SwichtOn");
        }
        
    }
}
