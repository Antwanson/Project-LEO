using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    
    public HealthBar healthBar;
    public EntityHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EntityHealth>();
        healthBar.SetMaxHealth(health.getMaxHP());
        Debug.Log(health.getMaxHP());
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(health.getHP());
    }
    
}
