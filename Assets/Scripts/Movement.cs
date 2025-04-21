using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int MovementSpeed;

    private void Update()
    {
        MoveTheHole();
    }

    private void MoveTheHole()
    {
        float rotationInput = Input.GetAxis("Horizontal");
        float movementInput = Input.GetAxis("Vertical");

        transform.Rotate(0.0f, rotationInput, 0.0f, Space.Self);
        
        Vector3 forwardMovement = transform.forward * movementInput * MovementSpeed * Time.deltaTime;
        transform.position += forwardMovement;
    }
}