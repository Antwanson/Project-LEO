using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SceneInitializer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public GameObject[] playerObjects;

    public String playerActionMap = "Ui";
    public Boolean allowLateJoin = true;
    void Start()
    {
        //instantiating the prefab at the center of the screen

        playerObjects = GameObject.FindGameObjectsWithTag("PlayerHandler");
        foreach (GameObject playerObject in playerObjects)
        {
            PlayerHandler playerHandlerComponent = playerObject.GetComponent<PlayerHandler>();
            PlayerInput playerInputComponent = playerObject.GetComponent<PlayerInput>();
            if (playerHandlerComponent != null)
            {
            playerHandlerComponent.InitPlayer(false);
            playerInputComponent.SwitchCurrentActionMap(playerActionMap);
            }
            else
            {
            Debug.LogError("PlayerHandler component not found on object with PlayerHandlerTag.");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public GameObject InstantiatePlayerInScene(Boolean isLateJoining){
        if(allowLateJoin == false && isLateJoining == true){
            return null;
        }
        if (prefab != null)
        {
            Vector3 screenCenter = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            screenCenter.z = 0; // Ensure the object is on the 2D plane
            GameObject playerInstance = Instantiate(prefab, screenCenter, Quaternion.identity);
            //get instance of the prefab that was instantiated
            return playerInstance;

        }
        else
        {
            Debug.LogError("Prefab not found or not set in the inspector.");
            return null;
        }
    }
}
