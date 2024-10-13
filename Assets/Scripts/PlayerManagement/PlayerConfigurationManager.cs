using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerConfigurationManager : MonoBehaviour {
    private List<PlayerConfiguration> playerConfigs;
    [SerializeField]
    public int maxPlayers = 4;

    public static PlayerConfigurationManager Instance { get; private set; }

    private void Awake() {
        if(Instance != null){
            Debug.Log("SINGLETON - Trying to create another instance of singleton");
        }
        else{
            Instance = this;
            DontDestroyOnLoad(Instance);
            playerConfigs = new List<PlayerConfiguration>();
        }
    }
    //function to set the color of player (used for character selection puck on character selection screen)
    public void SetPlayerColor(int playerIndex, Color characterColor){
        playerConfigs[playerIndex].playerColor = characterColor;
    }
    //
    public void ReadyPlayer(int playerIndex){

            //player is ready to start the game
            playerConfigs[playerIndex].IsReady = true;
            //if all players are ready and max players are reached, start the game
            if(playerConfigs.Count == maxPlayers && playerConfigs.All(p => p.IsReady == true)){
                SceneManager.LoadScene("SampleScene");
            }
    }

    public void HandlePlayerJoin(PlayerInput pi){
        //logging player index
        Debug.Log("Player Joined" + pi.playerIndex);

        
        //Checking to see if we haven't already added this player
        if(!playerConfigs.Any(p => p.playerIndex == pi.playerIndex)){
            //setting player input to be child of player manager
            pi.transform.SetParent(transform);
            //adding player to playerConfigs list 
            playerConfigs.Add(new PlayerConfiguration(pi));
            
        }
    }
}



public class PlayerConfiguration {

    public PlayerConfiguration(PlayerInput pi){
        playerIndex = pi.playerIndex;
        Input = pi;
    }
    public PlayerInput Input { get; set; }
    public int playerIndex { get; set; }
    public int characterNumber { get; set; }
    public Color playerColor { get; set; }
    public bool IsReady { get; set; }

}