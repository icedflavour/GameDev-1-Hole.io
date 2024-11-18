using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    [SerializeField] private int currentFood;
    [SerializeField] private int currentScore;
    public void AddFood(int additionalFood)
    {
        currentFood += additionalFood;
    }

    public void AddScore(int additionalScore)
    {
        currentScore += additionalScore;
    }
}
