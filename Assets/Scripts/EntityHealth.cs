using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EntityHealth : MonoBehaviour
{

    [Header("Entity Script Values")]
    [SerializeField] protected float maxHealth = 100; // Maximum health value
    [SerializeField] public float currentHealth = 100;   // Current health value

    void Start()
    {
        
    }

    // Method to take damage
     public void takeDamage(float amount)
    {
        currentHealth -= amount; // Subtract damage from current health
        if (currentHealth < 0)
        {
            currentHealth = 0; // Prevent negative health
        }

        //Debug.Log($"Took damage: {amount}. Current health: {currentHealth}");
        
    }

    public float getHP(){
        return currentHealth;
    }

    public float getMaxHP(){
        return maxHealth;
    }

    // Method to heal
    public void Heal(float amount)
    {
        currentHealth += amount; // Add healing amount to current health
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Prevent exceeding max health
        }

        Debug.Log($"Healed: {amount}. Current health: {currentHealth}");
    }

    // Method to get current health
    
    
}