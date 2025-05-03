using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNameScript : MonoBehaviour
{
   
    private Camera mainCam;

    //text mesh pro component
    public TMPro.TextMeshProUGUI textMeshProUGUI;

    private GameObject playerObject;
    private characterController characterController;

    void Start()
    {
        //get player object (attached to parent)
        playerObject = transform.parent.gameObject;
        //get character controller component from player object
        characterController = playerObject.GetComponent<characterController>();

        
        //make y scale negative if player is negative
        Debug.Log("Player scale: " + playerObject.transform.localScale.x);
        
        

        textMeshProUGUI.text = characterController.referenceToDaddy.playerName;

        mainCam = Camera.main;
    }

    void Update()
    {
        if (playerObject.transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        } else
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
    }

    void LateUpdate()
    {
        transform.forward = mainCam.transform.forward;
    }


}
