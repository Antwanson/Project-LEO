using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUI : MonoBehaviour
{
    
    public HealthBar healthBar;
    //public FavorBar favorBar;
    public EntityHealth health;
    //public EntityFavor favor;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<EntityHealth>();
        healthBar.SetMaxHealth(health.getMaxHP());
        Debug.Log(health.getMaxHP());
       
        //favor = GetComponent<EntityFavor>();
        //favorBar.SetMaxFavor(favor.getMaxFavor());
        //Debug.Log(favor.getMaxFavor());
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.SetHealth(health.getHP());
        //favorBar.SetFavor(favor.getFavor());
    }
    
}
