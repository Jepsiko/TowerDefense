using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BaseHealthUI : MonoBehaviour
{
    public void UpdateHealth(float health, float maxHealth)
    {
        GetComponent<TextMeshProUGUI>().text = "Base Health: " + (int) health;
    }
}
