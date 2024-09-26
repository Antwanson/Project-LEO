using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EntityHealth : MonoBehaviour
{
    [Header("Entity Script Values")]
    [SerializeField] public int maxHealth = 100; // Maximum health value
    [SerializeField] private int currentHealth;   // Current health value

    void Start()
    {
        currentHealth = maxHealth; // Set current health to max at the start
    }

    // Method to take damage
     public void TakeDamage(int amount)
    {
        currentHealth -= amount; // Subtract damage from current health
        if (currentHealth < 0)
        {
            currentHealth = 0; // Prevent negative health
        }

        Debug.Log($"Took damage: {amount}. Current health: {currentHealth}");

    }

    // Method to heal
    public void Heal(int amount)
    {
        currentHealth += amount; // Add healing amount to current health
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Prevent exceeding max health
        }

        Debug.Log($"Healed: {amount}. Current health: {currentHealth}");
    }
    
}