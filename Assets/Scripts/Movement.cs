using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private int MovementSpeed;

    private void Update()
    {
        if (Input.anyKey)
        {
            MoveTheHole();
        }
        
    }

    private void MoveTheHole()
    {

    }

}
