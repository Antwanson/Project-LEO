using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityFavor : MonoBehaviour
{
    [Header("Entity Script Values")]
    [SerializeField] protected int maxFavor = 100; // Maximum Favor value
    [SerializeField] protected int currentFavor = 0;   // Current Favor value
    
    void Start()
    {
        
    }

     // Method to take damage
     public void takeDamage(int amount)
    {
        currentFavor += amount; // Subtract damage from current health
        if (currentFavor < 0)
        {
            currentFavor = 0; // Prevent negative health
        }

        Debug.Log($"Took damage: {amount}. Current Favor: {currentFavor}");

    }

    public int getFavor(){
        return currentFavor;
    }

    public int getMaxFavor(){
        return maxFavor;
    }

    // Method to heal
    public void GainFavor(int amount)
    {
        currentFavor += amount; // Add healing amount to current health
        if (currentFavor > maxFavor)
        {
            currentFavor = maxFavor; // Prevent exceeding max Favor
        }

        Debug.Log($"GainedFavor: {amount}. Current Favor: {currentFavor}");
    }

    // Method to get current health

}
