using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
// get rect transform
public class CursorMovement : MonoBehaviour
{
    public RectTransform rectTransform;
    public Vector2 transformPosition;

    protected CharacterControls playerControls;
    [SerializeField]
    public int puckSpeedMultiplier = 10;

    protected List<RaycastResult> raycastResultsOld = new List<RaycastResult>();
    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log("X: " + transformPosition.x + " Y: " + transformPosition.y);
        // Create a pointer event for hovering
        PointerEventData pointer = new PointerEventData(EventSystem.current)
        {
            position = rectTransform.position
        };

        // Raycast to find UI elements under the cursor
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointer, raycastResults);

        // Process hover events
        foreach (RaycastResult result in raycastResults)
        {
            ExecuteEvents.Execute(result.gameObject, pointer, ExecuteEvents.pointerEnterHandler);
        }
        // Process exit events if the object is no longer under the cursor
        foreach (RaycastResult result in raycastResultsOld)
        {
            if (!raycastResults.Contains(result))
            {
                ExecuteEvents.Execute(result.gameObject, pointer, ExecuteEvents.pointerExitHandler);
            }
        }
        //store old raycast results
        raycastResultsOld = raycastResults;
    }

    void OnCursor(InputValue value)
    {
        transformPosition = value.Get<Vector2>();
        Debug.Log("ONCURSOR\n");
        Debug.Log("x" + transformPosition.x + "y" + transformPosition.y);
    }
    
    void OnSelect()
    {
        Debug.Log("ONSELECT\n");
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
}
