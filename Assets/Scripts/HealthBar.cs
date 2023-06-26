using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public GameObject gameOverText;

    private void Start()
    {
        ShowGameOver(false);
    }

    public void SetMaxHealth(int health)
    {
            slider.maxValue = health;
            slider.value = health;

            fill.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void ShowGameOver(bool isOver)
    {
        gameOverText.SetActive(isOver);
    }
}
