using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    private void Start() {
        slider.gameObject.SetActive(false);
    }

    public void UpdateHealth(float health, float maxHealth)
    {
        slider.gameObject.SetActive(true);
        slider.value = health / maxHealth;
    }
}
