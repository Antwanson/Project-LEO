using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraAdjustment : MonoBehaviour
{
    protected float upLimit;
    protected float downLimit;
    protected float leftLimit;
    protected float rightLimit;

    protected GameObject[] playerArray = null;

    protected Camera m_MainCamera;
    [SerializeField] protected float minimumZoom = 7f;

    protected bool splitScreenBool;

    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        m_MainCamera.enabled = true;

        InitializeLimits();

        if (GameObject.FindGameObjectsWithTag("Player") != null && GameObject.FindGameObjectsWithTag("Player").Length != 0){
            UpdateLimits();
            SetCamera();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Player") != null && GameObject.FindGameObjectsWithTag("Player").Length != 0){
            InitializeLimits();
            UpdateLimits();
            SetCamera();
        }
    }

    // Floats can't be null, so I'm using a random (the first) player to initialize them
    void InitializeLimits(){
        GameObject firstPlayer = GameObject.FindGameObjectsWithTag("Player")[0];

        leftLimit = firstPlayer.transform.position.x;
        rightLimit = firstPlayer.transform.position.x;
        downLimit = firstPlayer.transform.position.y;
        upLimit = firstPlayer.transform.position.y;
    }

    // Updates the limit variables to get the new camera center and size needed to display all players.
    void UpdateLimits()
    {
        playerArray = GameObject.FindGameObjectsWithTag("Player");
        
        foreach (GameObject player in playerArray) // Compares limits to all player positions
        {
            if (player.transform.position.x < leftLimit){
                leftLimit = player.transform.position.x;
            }
            if (player.transform.position.x > rightLimit)
            {
                rightLimit = player.transform.position.x;
            }
            if (player.transform.position.y < downLimit)
            {
                downLimit = player.transform.position.y;
            }
            if (player.transform.position.y > upLimit)
            {
                upLimit = player.transform.position.y;
            }
        }
    }

    // Snaps the camera to fit all players, used in the start so the camera starts at the right size.
    void SetCamera()
    {
        float xCenter = (leftLimit + rightLimit) / 2;
        float yCenter = (downLimit + upLimit) / 2;

        float xDistance = Mathf.Abs(leftLimit - rightLimit);
        float yDistance = Mathf.Abs(downLimit - upLimit);

        float xMinimumZoom = Mathf.Ceil(xDistance / 4);
        float yMinimumZoom = Mathf.Ceil(yDistance * 2 / 3);

        Vector3 center = new Vector3(xCenter, yCenter, -1f);

        Camera.main.transform.position = center;

        if (Mathf.Max(xMinimumZoom, yMinimumZoom) < minimumZoom)
        {
            Camera.main.orthographicSize = minimumZoom;
        }
        else if (xMinimumZoom > yMinimumZoom)
        {
            Camera.main.orthographicSize = xMinimumZoom;
        }
        else
        {
            Camera.main.orthographicSize = yMinimumZoom;
        }

        // Need to set up an if-statement that requires the center to deviate significantly to institute a change, so it doesn't
        // wildly get off-center
    }

    // Centers the camera between the limits and changes the camera size to approach the desired one displaying all players
    void UpdateCamera(){
        float xCenter = (leftLimit + rightLimit) / 2;
        float yCenter = (downLimit + upLimit) / 2;

        float xDistance = Mathf.Abs(leftLimit - rightLimit);
        float yDistance = Mathf.Abs(downLimit - upLimit);

        float xMinimumZoom = Mathf.Ceil(xDistance / 4);
        float yMinimumZoom = Mathf.Ceil(yDistance * 2 / 3);
        
        if (yDistance <= 5f){
            yCenter += 3f / (1 + yDistance);
        }

        Vector3 center = new Vector3(xCenter, yCenter, -1f);

        Camera.main.transform.position = center;

        // Ensures a minimum zoom so that it doesn't follow the players too closely when bundled together.
        if (Mathf.Max(xMinimumZoom, yMinimumZoom) < minimumZoom)
        {
            IncrementalAdjustTo(minimumZoom);
        }
        else if (xMinimumZoom > yMinimumZoom){
            IncrementalAdjustTo(xMinimumZoom);
        }
        else{
            IncrementalAdjustTo(yMinimumZoom);
        }

        // This code may be developed in the future to have a smoother change or be more rigid in accordance to variables set by a
        // specific map.
    }

    // This method makes the camera's current size change to a target size in increments that are multiplied by their distance to
    // to the target. The farther it is, the faster it adjusts, until it reaches a threshold and snaps to the target size.
    void IncrementalAdjustTo(float targetSize){
        int numToTarget = (int) Mathf.Abs(Camera.main.orthographicSize - targetSize) + 1;

        if (Mathf.Abs(Camera.main.orthographicSize - targetSize) <= 0.03f * numToTarget){
            Camera.main.orthographicSize = targetSize;
        }
        else if (Camera.main.orthographicSize < targetSize) {
            Camera.main.orthographicSize += 0.03f * numToTarget;
        }
        else{
            Camera.main.orthographicSize -= 0.03f * numToTarget;
        }
    }
}
