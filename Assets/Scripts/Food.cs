using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] private int foodValue;
    [SerializeField] private int scoreValue;

    private void OnTriggerExit(Collider other) 
    {
        if (other.tag == "EatingTrigger" && (transform.position.y < other.transform.position.y))
        {
            var hole = other.gameObject.GetComponentInParent<Hole>();
            StartEating(hole);
        }
    }

    public void StartEating(Hole hole)
    {
        hole.AddFood(foodValue);
        hole.AddScore(scoreValue);
        Destroy(gameObject);
    }
}
