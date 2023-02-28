using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCutWheel : MonoBehaviour
{

    [SerializeField]private float speed = 1f; // Default speed of 1x

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.speed = speed; // Set the animation speed to the desired speed
    }
}
