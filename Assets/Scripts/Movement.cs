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

        transform.Rotate(0.0f, rotationInput, 0.0f, Space.Self);

        rb.velocity = transform.forward * movementInput * MovementSpeed;
    }

    //rb.velocity = new Vector3(Input.GetAxis("Horizontal") * MovementSpeed, 0f, Input.GetAxis("Vertical") * MovementSpeed);
}

