using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerGhostBlue : MonoBehaviour
{
    [Header("Ghost Variables")]
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _turnSpeed = 360;
    [SerializeField] private Animator animator;
    [Header("Target Variables")]
    [SerializeField] private GameObject Player;
    [SerializeField] private float maxDistance = 10f;

    private Vector3 _input;

    private void Update()
    {
        GatherInput();
        Look();
        Animate(_input.x, _input.z);

        VerificationDistancePlayer();
    }

    private void FixedUpdate()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //BackToPlayer();
        }
    }

    private void GatherInput()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    private void Look()
    {
        if (_input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(_input.ToIso(), Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
    }

    private void Move()
    {
        Vector3 movement = _input.normalized * _speed * Time.deltaTime;
        _rb.MovePosition(transform.position + movement);

        //_rb.MovePosition(transform.position + transform.forward * _input.normalized.magnitude * _speed * Time.deltaTime);
    }

    void Animate(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        animator.SetBool("IsWalking", walking);
    }

    private void BackToPlayer()
    {
       
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<CreateGhosts>().enabled = true;
        this.gameObject.GetComponent<PlayerControllerGhostBlue>().enabled = false;        
      
        Destroy(gameObject);
    }

    private void VerificationDistancePlayer()
    {
        if (Player == null)
        {
            // If targetObject is null, try to find it by tag
            Player = GameObject.FindGameObjectWithTag("Player");

            if (Player == null)
            {
                Debug.LogWarning("Target object not found in scene.");
                return;
            }
        }

        if (Vector3.Distance(transform.position, Player.transform.position) > maxDistance)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponent<CreateGhosts>().enabled = true;

            Destroy(gameObject);
        }
    }

}
