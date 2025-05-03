using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntensityManager : MonoBehaviour
{
    public MusicManager musicManager;
    public GameObject Background;
    //background sprite renderer
    public SpriteRenderer backgroundSpriteRenderer;
    public GameObject[] players;
    public EntityHealth playerHealth;
    public bool isIntense = false;

    public Color backgroundColor;
    
    // Start is called before the first frame update
    void Start()
    {
        //get music manager from current scene
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        //background is set in the inspector
        backgroundSpriteRenderer = Background.GetComponent<SpriteRenderer>();

        //set the background color to currently set color
        backgroundColor = backgroundSpriteRenderer.color;

        //players are grabbed from GameObjects with the tag "Player"
        players = GameObject.FindGameObjectsWithTag("Player");

        Debug.Log("Players: " + players.Length);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        if(isIntense == false)
        {
            //if player health is less than 25% of max
            int i = 0;
            while (i < players.Length)
            {

                playerHealth = players[i].GetComponent<EntityHealth>();

                Debug.Log("Player Health: " + playerHealth.getHP() + " Max HP: " + playerHealth.getMaxHP());
                if (playerHealth.getHP() <= playerHealth.getMaxHP() * 0.35f)
                {
                    isIntense = true;
                    musicManager.SwitchIntenseCombat();
                    
                    break;
                }
                i++;
            }
        }
        else{
            //slowly make the background color red
            backgroundColor = Color.Lerp(backgroundColor, Color.red, Time.deltaTime * 0.5f);
            backgroundSpriteRenderer.color = backgroundColor;
        }
    }
}
