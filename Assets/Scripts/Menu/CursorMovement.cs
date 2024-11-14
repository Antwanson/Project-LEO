using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using System;
// get rect transform
public class CursorMovement : MonoBehaviour
{
    public RectTransform rectTransform;
    public Vector2 transformPosition;

    public int playerIndex;

    protected CharacterControls playerControls;
    [SerializeField]
    public int puckSpeedMultiplier;

    [SerializeField]
    public List<RaycastResult> raycastResultsOld = new List<RaycastResult>();
    // Start is called before the first frame update
    void Start()
    {
        // Set the puck speed multiplier based on the screen resolution - Jacob
        puckSpeedMultiplier = (Screen.currentResolution.width / 1920) + (Screen.currentResolution.height / 1080) * 10;

        rectTransform = GetComponent<RectTransform>();
        playerControls = new CharacterControls();
        // Reparent to the canvas in the scene
        Canvas canvas = FindObjectOfType<Canvas>();
        if (canvas != null)
        {
            rectTransform.SetParent(canvas.transform, false);
        }
        else
        {
            Debug.LogError("Canvas not found in the scene.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // rectTransform.anchoredPosition = new Vector2(Input.mousePosition.x * 10, Input.mousePosition.y * 10);
        //log movement
        rectTransform.position = new Vector3(transformPosition.x * puckSpeedMultiplier + rectTransform.position.x, rectTransform.position.y + transformPosition.y * puckSpeedMultiplier, rectTransform.position.z);
        //Debug.Log("X: " + transformPosition.x + " Y: " + transformPosition.y);
        // Create a pointer event for hovering
        updateHover();
    }

    public void CursorTriggered(InputValue value)
    {
        transformPosition = value.Get<Vector2>();
        //updateHover();
        //Debug.Log("ONCURSOR\n");
        //Debug.Log("x" + transformPosition.x + "y" + transformPosition.y);
    }
    
    public void SelectTriggered()
    {
        //Debug.Log("ONSELECT\n");
        PointerEventData pointer = new PointerEventData(EventSystem.current)
        {
            position = rectTransform.position
        };

        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

        foreach (RaycastResult result in raycastResults)
        {
            Button button = result.gameObject.GetComponent<Button>();
            if (button != null)
            {
            button.onClick.Invoke();
            break;
            }
        }
    }
    public void updateHover(){
        PointerEventData pointer = new PointerEventData(EventSystem.current)
        {
            position = rectTransform.position
        };

        // Raycast to find UI elements under the cursor
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);
        // Filter out only the buttons from the raycast results
        raycastResults = raycastResults.FindAll(result => result.gameObject.GetComponent<Button>() != null);
        
        
        foreach (RaycastResult result in raycastResults)
        {
            ExecuteEvents.Execute(result.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
        }
        // Process exit events if the object is no longer under the cursor
        foreach (RaycastResult result in raycastResultsOld)
        {
            /*
            if (!raycastResults.Contains(result.gameObject))
            {
                //Debug.Log(result);
                ExecuteEvents.Execute(result.gameObject, pointer, ExecuteEvents.pointerExitHandler);
            }
            */

            foreach (RaycastResult resultNew in raycastResults)
            {
                if (result.gameObject != resultNew.gameObject)
                {
                    ExecuteEvents.Execute(result.gameObject, pointer, ExecuteEvents.pointerExitHandler);
                }
            }

        }
        
        //log old and new results
        Debug.Log("Old: " + raycastResultsOld.Count + " New: " + raycastResults.Count);
        //store old raycast results
        raycastResultsOld = raycastResults;
    }
}
