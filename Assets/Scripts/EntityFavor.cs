using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EntityFavor : MonoBehaviour
{
    [Header("Entity Script Values")]
    [SerializeField] protected float maxFavor = 100; // Maximum Favor value
    [SerializeField] protected float currentFavor = 0;   // Current Favor value

    // Method to modify damage by addition / subtraction
    public void addFavor(float amount)
    {
        currentFavor += amount;
        if (currentFavor < 0)
        {
            currentFavor = 0;
        }
        if (currentFavor > maxFavor)
        {
            currentFavor = maxFavor;
        }

        Debug.Log($"Modified favor by: {amount}. Current Favor: {currentFavor}");
    }
    public void setFavor(float amount)
    {
        currentFavor = amount;
        if (currentFavor < 0)
        {
            currentFavor = 0;
        }
        if (currentFavor > maxFavor)
        {
            currentFavor = maxFavor;
        }

        Debug.Log($"Set favor to: {amount}. Current Favor: {currentFavor}");
    }

    public void maxOutFavor() {
        currentFavor = maxFavor;
    }

    public float getFavor(){
        return currentFavor;
    }

    public float getMaxFavor(){
        return maxFavor;
    }
}