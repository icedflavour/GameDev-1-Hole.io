using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int MovementSpeed;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        MoveTheHole();
    }

    private void MoveTheHole()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        float movementInput = Input.GetAxis("Vertical");

        // Rotate the hole
        transform.Rotate(0.0f, rotationInput, 0.0f, Space.Self);

        // Move the hole
        Vector3 forwardMovement = transform.forward * movementInput * MovementSpeed * Time.deltaTime;
        transform.position += forwardMovement;
    }
}

