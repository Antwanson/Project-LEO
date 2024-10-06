using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

// Coded by Jacob, using as reference...
// https://youtu.be/ROwsdftEGF0?si=4V8KzqGZOYjFj7oI "The right way to pause a game in Unity" by Game Dev Beginner
// https://youtu.be/JivuXdrIHK0?si=Es6M1hIEygPNPjo8 "PAUSE MENU in Unity" by Brackeys

// Setup within a scene requires copy pasting the GameObject "PauseScreen" and
// inputting the three serialized fields in PauseScreen's PauseMenu script.

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;

    [SerializeField] protected GameObject pauseMenuUI;

    [SerializeField] protected String uiInputMap;
    [SerializeField] protected String gameplayInputMap;
    [SerializeField] protected CharacterControls playerControls;

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
        if (GameObject.FindGameObjectsWithTag("Player") != null) {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players) {
                PlayerInput playerInput = player.GetComponent<PlayerInput>();
                playerInput.SwitchCurrentActionMap(gameplayInputMap);
            }
        }
    }

    protected void PauseGame() {
        pauseMenuUI.SetActive(true); // Displays pause menu

        gameIsPaused = true;

        Time.timeScale = 0f; // Pauses time

        AudioListener.pause = true; // Resumes audio

        // If there are players, it goes to each and sets their controls to ui
        if (GameObject.FindGameObjectsWithTag("Player") != null) {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            foreach (GameObject player in players) {
                PlayerInput playerInput = player.GetComponent<PlayerInput>();
                playerInput.SwitchCurrentActionMap(uiInputMap);
            }
        }
    }
}
