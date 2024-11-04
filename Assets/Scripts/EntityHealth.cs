using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EntityHealth : MonoBehaviour
{
    public StateController stateMachine;

    [Header("Entity Script Values")]
    [SerializeField] protected int maxHealth = 100; // Maximum health value
    [SerializeField] public int currentHealth = 100;   // Current health value

    void Start()
    {
        stateMachine = GetComponent<StateController>();
    }

    // Method to take damage
     public void takeDamage(int amount)
    {
        currentHealth -= amount; // Subtract damage from current health
        if (currentHealth < 0)
        {
            currentHealth = 0; // Prevent negative health
        }

        //Debug.Log($"Took damage: {amount}. Current health: {currentHealth}");
        stateMachine.machine.Set(stateMachine.hurtState);
    }

    public int getHP(){
        return currentHealth;
    }

    public int getMaxHP(){
        return maxHealth;
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

    // Method to get current health
    
    
}