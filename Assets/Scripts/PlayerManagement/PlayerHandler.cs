using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;
public class PlayerHandler : MonoBehaviour
{
    public PlayerConfigurationManager playerConfigurationManager;
    public SceneInitializer sceneInitializer;
    public GameObject currentPlayerObject = null;
    private PlayerInput playerInput;
    
    [Header("Player attributes")]
    // stores player color
    [SerializeField] public Color playerColor;
    void Awake()
    {
        playerConfigurationManager = GameObject.FindGameObjectWithTag("PlayerConfigurationManager").GetComponent<PlayerConfigurationManager>();
        playerInput = GetComponent<PlayerInput>();
        DontDestroyOnLoad(this);
        InitPlayer(true);
        //set color of player to random vibrant color generate a color do not use another class
        playerColor = new Color(255, 0, 0);
        //color set to red

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    } 
    //essentially sets up the player in the scene and links it with the playerhandler. Called on start and by scene intializer
    public void InitPlayer(Boolean isLateJoining)
    {
        //get SceneInitializer component from the scene initializer in scene with tag "SceneInitializer"
        sceneInitializer = GameObject.FindGameObjectWithTag("SceneInitializer").GetComponent<SceneInitializer>();
        if(sceneInitializer != null) {
        //instantiate player in scene
        currentPlayerObject = sceneInitializer.InstantiatePlayerInScene(isLateJoining);
        //color
        //setColor();
        }
        else {
            Debug.LogError("SceneInitializer not found in the scene");
        }
    }
    void setColor(){
        //sets color based on stored color
        Image image = currentPlayerObject.GetComponent<Image>();
        if(image != null){
            image.color = playerColor;
        }
        else {
            Debug.Log("Image component not found on player object");
        }

    }
    void OnCursor(InputValue value)
    {
        CursorMovement cursorMovement = currentPlayerObject.GetComponent<CursorMovement>();
        cursorMovement.CursorTriggered(value);
    }
    void OnSelect()
    {
        CursorMovement cursorMovement = currentPlayerObject.GetComponent<CursorMovement>();
        cursorMovement.SelectTriggered();
    }
    void OnJump(){
        characterController playerControls = currentPlayerObject.GetComponent<characterController>();
        playerControls.JumpTriggered();
    }
    void OnMovement(InputValue value)
    {
        characterController playerControls = currentPlayerObject.GetComponent<characterController>();
        playerControls.MovementTriggered(value);
    }
    void OnAttackNeutral()
    {
        characterController playerControls = currentPlayerObject.GetComponent<characterController>();
        playerControls.isAttackingNeutral = true;
    }
    void OnAttackFavor()
    {
        characterController playerControls = currentPlayerObject.GetComponent<characterController>();
        playerControls.isAttackingFavor = true;
    }
    void OnDash()
    {
        StateController stateMachine = currentPlayerObject.GetComponent<StateController>();
        stateMachine.machine.Set(stateMachine.dashState);
    }
}
