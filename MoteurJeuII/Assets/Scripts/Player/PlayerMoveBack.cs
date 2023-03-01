using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBack : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private Animator animator;
    [SerializeField] private float rotationSpeed = 10f;

    private bool isAttacking = false;

    private Vector3 movement;
    private Rigidbody playerRigidbody;



    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (!isAttacking)
        {
            Move(horizontal, vertical);
            Rotate(horizontal, vertical);
        }
        
        Animate(horizontal, vertical);
        Attack();
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * moveSpeed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Rotate(float h, float v)
    {
        if (h != 0f || v != 0f)
        {
            Quaternion newRotation = Quaternion.LookRotation(movement);
            playerRigidbody.MoveRotation(Quaternion.Slerp(playerRigidbody.rotation, newRotation, Time.deltaTime * rotationSpeed));
        }
    }

    void Animate(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        animator.SetBool("IsWalking", walking);
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("Attack");
            isAttacking = true;
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack01") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)
        {
            isAttacking = false;
        }
    }

}
