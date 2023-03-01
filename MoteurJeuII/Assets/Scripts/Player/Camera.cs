using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Vector3 offset = new Vector3();
    private float smoothTime = 0.20f;

    [SerializeField] private Transform target;

    private void Start()
    {
        offset = new Vector3(0f, 15f, -7f);
        smoothTime = 0.20f;
    }

    private void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothTime);
    }
}
