using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
public class PlayerHandler : MonoBehaviour
{

    public SceneInitializer sceneInitializer;
    public GameObject currentPlayerObject = null;
    void Awake()
    {
        DontDestroyOnLoad(this);
        InitPlayer();
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
    public void InitPlayer()
    {
        //get SceneInitializer component from the scene initializer in scene with tag "SceneInitializer"
        sceneInitializer = GameObject.FindGameObjectWithTag("SceneInitializer").GetComponent<SceneInitializer>();
        if(sceneInitializer != null) {
        //instantiate player in scene
        currentPlayerObject = sceneInitializer.InstantiatePlayerInScene();
        }
        else {
            Debug.LogError("SceneInitializer not found in the scene");
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
}
