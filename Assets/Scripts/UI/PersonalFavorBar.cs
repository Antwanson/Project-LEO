using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalFavorBar : MonoBehaviour
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
    private EntityFavor entityHealth;
    private Transform hb;
    private Transform hbTop;



    void Start()
    {
        // hb = healthBottom.GetComponent<Transform>();
        // hbTop = healthTop.GetComponent<Transform>();

        Width = healthTop.transform.localScale.x;

        entityHealth = player.GetComponent<EntityFavor>();
        Health = entityHealth.getFavor();
        MaxHealth = entityHealth.getMaxFavor();
    }

    // Update is called once per frame
    void Update()
    {
        Health = entityHealth.getFavor();
        MaxHealth = entityHealth.getMaxFavor();

        Vector3 currentScale = healthTop.transform.localScale;
        currentScale.x = Health/MaxHealth * Width;
        healthTop.transform.localScale = currentScale;
        //healthTop.transform.localScale.x = Health/MaxHealth * Width;
        
    }



}
