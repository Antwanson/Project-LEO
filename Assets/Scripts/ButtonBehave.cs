using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehave : MonoBehaviour
{
    [SerializeField] public String scene;
    
    public void PlayGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void selectScene(){
        SceneManager.LoadScene(scene);
    }

    public void Back(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
    //Function will be needed late, need to ask Jay
    /*public void GetScene(String name){
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadScene(name);

    }*/
    public void QuitGame(){
        Debug.Log("Quit Game!");
        Application.Quit();
    }
}
