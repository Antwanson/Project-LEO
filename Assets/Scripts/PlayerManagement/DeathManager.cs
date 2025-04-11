using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;

public class DeathManager : MonoBehaviour
{
    public PlayerHandler playerHandler;
    public GameObject currentPlayerObject;
    public SceneInitializer sceneInitializer;
    public DeathManager(PlayerHandler playerHandler){
        this.playerHandler = playerHandler;
        this.currentPlayerObject = playerHandler.currentPlayerObject;
        this.sceneInitializer = playerHandler.sceneInitializer;
    }

}