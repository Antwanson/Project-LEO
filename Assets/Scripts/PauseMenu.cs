using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

// Coded by Jacob, using as reference...
// https://youtu.be/ROwsdftEGF0?si=4V8KzqGZOYjFj7oI "The right way to pause a game in Unity" by Game Dev Beginner
// https://youtu.be/JivuXdrIHK0?si=Es6M1hIEygPNPjo8 "PAUSE MENU in Unity" by Brackeys

// Setup within a scene requires copy pasting the GameObject "PauseScreen" and
// inputting the three serialized fields in PauseScreen's PauseMenu script.

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;

    [SerializeField] protected GameObject pauseMenuUI;

    [SerializeField] protected String uiInputMap = "Ui";
    [SerializeField] protected String gameplayInputMap = "BaseCombat";
    [SerializeField] protected CharacterControls playerControls;

    public GameObject cursorPrefab;

    protected void Update() {
        // Had to hard code this because InputSystem outside "On[InputAction]" is janky
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7)) {
            Pause();
        }
    }

    public bool GetGameIsPaused() {
        return gameIsPaused;
    }

    protected void Start() {
        gameIsPaused = false;
    }

    public void Pause() {
        if (gameIsPaused) {
            ResumeGame();
        }
        else {
            PauseGame();
        }
    }

    public void ResumeGame() {
        pauseMenuUI.SetActive(false); // Removes pause menu graphic

        gameIsPaused = false;

        Time.timeScale = 1f; // Resume time

        AudioListener.pause = false; // Resume audio

        // If there are players, it goes to each and sets their controls to gameplay
        if (GameObject.FindGameObjectsWithTag("PlayerHandler") != null) {
            GameObject[] players = GameObject.FindGameObjectsWithTag("PlayerHandler");
            foreach (GameObject player in players) {
                Debug.Log("Player found: " + player.name);
                //get cursor (current player object)
                PlayerHandler playerHandler = player.GetComponent<PlayerHandler>();
                if (playerHandler != null) {
                    //set the current player object to the stored player object
                    GameObject cursorPrefabInstance = playerHandler.currentPlayerObject;
                    playerHandler.currentPlayerObject = playerHandler.storedPlayerObject;
                    
                    //destroy the cursor object
                    Destroy(cursorPrefabInstance);

                    //switch the current action map of player handler to "Gameplay"
                    PlayerInput playerInput = player.GetComponent<PlayerInput>();
                    if (playerInput != null) {
                        playerInput.SwitchCurrentActionMap(gameplayInputMap);
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

    protected void PauseGame() {
        pauseMenuUI.SetActive(true); // Displays pause menu

        gameIsPaused = true;

        Time.timeScale = 0f; // Pauses time

        AudioListener.pause = true; // Resumes audio

        // If there are players, it goes to each and sets their controls to ui
        if (GameObject.FindGameObjectsWithTag("PlayerHandler") != null) {
            GameObject[] players = GameObject.FindGameObjectsWithTag("PlayerHandler");
            foreach (GameObject player in players) {
                Debug.Log("Player found: " + player.name);
                //for each player handler we need to store the current player object as the stored player object
                PlayerHandler playerHandler = player.GetComponent<PlayerHandler>();
                if (playerHandler != null) {
                    //set the current player object to the stored player object
                    playerHandler.storedPlayerObject = playerHandler.currentPlayerObject;
                    
                    //instantiate a cursor object in the scene and set it to the current player object, the cursor's parent is the pauseMenuUI
                    GameObject cursor = Instantiate(cursorPrefab, pauseMenuUI.transform);
                    cursor.transform.SetParent(pauseMenuUI.transform, false);

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

