using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;
using TMPro;

public class DeathManager : MonoBehaviour
{
    public List<PlayerHandler> playerHandlers = new List<PlayerHandler>();
    public SceneInitializer sceneInitializer;

    public GameObject deathCanvas;

    public GameObject cursorPrefab;
    public String uiInputMap = "Ui";
    public String gameplayInputMap = "BaseCombat";
    public String playerActionMap = "PlayerActionMap";

    public GameObject pauseMenu;
    public TextMeshProUGUI playerNameText;

    public bool isGameOver = false;
    //on start
    void Start()
    {
        //get the player handlers in the scene
        playerHandlers.AddRange(GameObject.FindObjectsOfType<PlayerHandler>());
        
        //for each handler log the handler
        foreach (PlayerHandler playerHandler in playerHandlers)
        {
            Debug.Log("PlayerHandler found: " + playerHandler.name);
        }

        
    }

    void Update()
    {
        //check if players are alive
        if (isGameOver == false)
        {
            checkAlivePlayers();
        }
    }

    void checkAlivePlayers()
    {
        int alivePlayers = 0;
        foreach (PlayerHandler playerHandler in playerHandlers)
        {
            if (playerHandler.currentPlayerObject != null){
                alivePlayers++;
            }
        
        }
        //Debug.Log("Alive players: " + alivePlayers);
        if (alivePlayers < 2)
        {
            isGameOver = true;
            //disable pause menu
            pauseMenu.SetActive(false);
            //if no players are alive, restart the scene
            Debug.Log("Game Over, restarting scene...");
            //show death canvas
            deathCanvas.SetActive(true);
            //set the player name text to the name of the player that is still alive
            foreach (PlayerHandler playerHandler in playerHandlers)
            {
                if (playerHandler.currentPlayerObject != null){
                    playerNameText.text = playerHandler.playerName + " is the winner!";
                }
            }


            if (GameObject.FindGameObjectsWithTag("PlayerHandler") != null) {
            GameObject[] players = GameObject.FindGameObjectsWithTag("PlayerHandler");
                foreach (GameObject player in players) {
                    Debug.Log("Player found: " + player.name);
                    //for each player handler we need to store the current player object as the stored player object
                    PlayerHandler playerHandler = player.GetComponent<PlayerHandler>();
                    if (playerHandler != null) {
                        //set the current player object to the stored player object
                        playerHandler.storedPlayerObject = playerHandler.currentPlayerObject;
                        
                        //instantiate a cursor object in the scene and set it to the current player object, the cursor's parent is the deathCanvas
                        GameObject cursor = Instantiate(cursorPrefab, deathCanvas.transform);
                        cursor.transform.SetParent(deathCanvas.transform, false);

                        //set the cursor to the current player object
                        playerHandler.currentPlayerObject = cursor;

                        //switch the current action map of player handler to "Ui"
                        PlayerInput playerInput = player.GetComponent<PlayerInput>();
                        if (playerInput != null) {
                            playerInput.SwitchCurrentActionMap(uiInputMap);
                        }
                        else {
                            Debug.LogError("PlayerInput not found on player object: " + player.name);
                        }
                        
                    }
                    else {
                        Debug.LogError("PlayerHandler not found on player object: " + player.name);
                    }
                }
            }
        }
    }

    public void QuitGame() {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
    public void ToMenu() {
        Debug.Log("Going to menu...");
        // Load the main menu scene (replace "MainMenu" with your actual scene name)
        UnityEngine.SceneManagement.SceneManager.LoadScene("Home_Screen");
    }

    public void ToCharacterSelect() {
        Debug.Log("Going to character select...");
        // Load the character select scene (replace "CharacterSelect" with your actual scene name)
        UnityEngine.SceneManagement.SceneManager.LoadScene("CharacterSelect");
    }
}
