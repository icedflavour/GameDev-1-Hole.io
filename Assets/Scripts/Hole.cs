using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class Hole : MonoBehaviour
{
    public float StarvationRate;
    public float FoodScore;
    public float MaxFoodScore;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI MaxScoreText;
    public Slider HealthBar;

    private void Start()
    {
        MaxFoodScore = FoodScore;
        ScoreText.text = Math.Floor(FoodScore).ToString();
        MaxScoreText.text = Math.Floor(MaxFoodScore).ToString();
        HealthBar.maxValue = MaxFoodScore;
        HealthBar.value = FoodScore;
    }

    public void Eat(float changeFoodScore)
    {

        FoodScore += changeFoodScore;

        if (FoodScore < 0)
        {
            FoodScore = 0;
        }

        ScoreText.text = Math.Floor(FoodScore).ToString();

        if (FoodScore > MaxFoodScore)
        {
            MaxFoodScore = FoodScore;
            HealthBar.maxValue = MaxFoodScore;
            MaxScoreText.text = Math.Floor(MaxFoodScore).ToString();
        }

        HealthBar.value = FoodScore;
        transform.localScale += new Vector3(changeFoodScore / 10, changeFoodScore / 10, changeFoodScore / 10);
    }

	private void FixedUpdate()
	{
        if (FoodScore > 0)
        {
            var StarveValue = FoodScore * StarvationRate;
            Eat(-StarveValue);
        }
	}
}
