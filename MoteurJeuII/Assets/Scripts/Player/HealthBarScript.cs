using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image HealthBar;
    private float CurrentHealth;
    private float MaxHealth = 100f;
    PlayerHealth Player;

    private void Start()
    {
        HealthBar = GetComponent<Image>();
        Player = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        CurrentHealth = Player.GetCurrentHealth(); // Access the player's current health
        HealthBar.fillAmount = CurrentHealth / MaxHealth;
    }
}
