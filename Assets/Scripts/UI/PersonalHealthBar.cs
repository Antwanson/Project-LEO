using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalHealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public float Health, MaxHealth, Width;

    [Header("Reference Components")]
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject healthBottom;
    [SerializeField]
    private GameObject healthTop;
    private EntityHealth entityHealth;
    private Transform hb;
    private Transform hbTop;



    void Start()
    {
        // hb = healthBottom.GetComponent<Transform>();
        // hbTop = healthTop.GetComponent<Transform>();

        Width = healthTop.transform.localScale.x;

        entityHealth = player.GetComponent<EntityHealth>();
        Health = entityHealth.getHP();
        MaxHealth = entityHealth.getMaxHP();
    }

    // Update is called once per frame
    void Update()
    {
        Health = entityHealth.getHP();
        MaxHealth = entityHealth.getMaxHP();

        Vector3 currentScale = healthTop.transform.localScale;
        currentScale.x = Health/MaxHealth * Width;
        healthTop.transform.localScale = currentScale;
        //healthTop.transform.localScale.x = Health/MaxHealth * Width;
        
    }



}
