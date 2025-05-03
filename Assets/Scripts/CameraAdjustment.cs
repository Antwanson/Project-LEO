using System;
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

    protected float centerAdjust;

    protected float[] mapBounds = new float[4];

    protected GameObject[] playerArray = null;

    protected Camera m_MainCamera;
    [SerializeField] protected float minimumZoom;

    protected bool splitScreenBool;

    // Start is called before the first frame update
    void Start()
    {
        m_MainCamera = Camera.main;
        m_MainCamera.enabled = true;

        DetermineVariables();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Player") != null && GameObject.FindGameObjectsWithTag("Player").Length != 0){
            InitializeLimits();
            UpdateLimits();
            UpdateCamera();
        }
        else {
            ResetLimits();
        }
    }

    void DetermineVariables() {
        mapBounds[0] = GameObject.Find("KillZoneU").GetComponent<Transform>().position.y;
        mapBounds[1] = GameObject.Find("KillZoneD").GetComponent<Transform>().position.y;
        mapBounds[2] = GameObject.Find("KillZoneL").GetComponent<Transform>().position.x;
        mapBounds[3] = GameObject.Find("KillZoneR").GetComponent<Transform>().position.x;

        centerAdjust = (mapBounds[0] - mapBounds[1]) / 10 + 2;

        minimumZoom = Mathf.Ceil(Mathf.Sqrt(mapBounds[3] - mapBounds[2]));
    }

    void ResetLimits() {
        leftLimit = 0;
        rightLimit = 0;
        upLimit = centerAdjust;
        downLimit = 0;

        SetCamera();
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

        yCenter += centerAdjust / (1 + Mathf.Abs(yCenter - (mapBounds[0] + mapBounds[1]) / 2) / minimumZoom);

        float xDistance = Mathf.Abs(leftLimit - rightLimit);
        float yDistance = Mathf.Abs(downLimit - upLimit);

        float xMinimumZoom = Mathf.Ceil(xDistance / 2);
        float yMinimumZoom = Mathf.Ceil(yDistance * 2 / 3);

        Vector3 center = new Vector3(xCenter, yCenter, -1f);

        Camera.main.transform.position = center;

        float newZoom = Mathf.Max(Mathf.Max(xMinimumZoom, yMinimumZoom), minimumZoom);

        if (newZoom != Camera.main.orthographicSize)
            Debug.Log("Zoom has been set to " + newZoom);

        Camera.main.orthographicSize = newZoom;

        // Need to set up an if-statement that requires the center to deviate significantly to institute a change, so it doesn't
        // wildly get off-center
    }

    // Centers the camera between the limits and changes the camera size to approach the desired one displaying all players
    void UpdateCamera(){
        float xCenter = (leftLimit + rightLimit) / 2;
        float yCenter = (downLimit + upLimit) / 2;

        yCenter += centerAdjust / (1 + Mathf.Abs(yCenter - (mapBounds[0] + mapBounds[1]) / 2) / centerAdjust);

        if (yCenter > (mapBounds[0] + mapBounds[1]) * 0.75f) {
            yCenter = (mapBounds[0] + mapBounds[1]) * 0.75f;
        }

        float xDistance = Mathf.Abs(leftLimit - rightLimit);
        float yDistance = Mathf.Abs(downLimit - upLimit);

        float xMinimumZoom = Mathf.Ceil(xDistance / 3);
        float yMinimumZoom = Mathf.Ceil(yDistance * 2 / 3);

        Vector3 center = new Vector3(xCenter, yCenter, -1f);

        Camera.main.transform.position = center;

        float newZoom = Mathf.Max(Mathf.Max(xMinimumZoom, yMinimumZoom), minimumZoom);

        // Ensures a minimum zoom so that it doesn't follow the players too closely when bundled together.
        IncrementalAdjustTo(newZoom);

        // This code may be developed in the future to have a smoother change or be more rigid in accordance to variables set by a
        // specific map.
    }

    // This method makes the camera's current size change to a target size in increments that are multiplied by their distance to
    // to the target. The farther it is, the faster it adjusts, until it reaches a threshold and snaps to the target size.
    void IncrementalAdjustTo(float targetSize){
        float numToTarget = Mathf.Abs(Camera.main.orthographicSize - targetSize) + 1;
        numToTarget -= numToTarget % 0.1f;

        if (Mathf.Abs(Camera.main.orthographicSize - targetSize) <= 0.05f * numToTarget){
            Camera.main.orthographicSize = targetSize;
        }
        else if (Camera.main.orthographicSize < targetSize) {
            Camera.main.orthographicSize += 0.05f * numToTarget;
        }
        else{
            Camera.main.orthographicSize -= 0.05f * numToTarget;
        }
    }
}
