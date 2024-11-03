using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour {

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake() {
        if(Instance != null){
            Debug.Log("SINGLETON - Trying to create another instance of singleton");
        }
        else{
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
    }
    //function to set the color of player (used for character selection puck on character selection screen
}