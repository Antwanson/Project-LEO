using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
// get rect transform
public class CursorMovement : MonoBehaviour
{
    public RectTransform rectTransform;
    public Vector2 transformPosition;

    protected CharacterControls playerControls;


    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        playerControls = new CharacterControls();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition = new Vector2(Input.mousePosition.x * 10, Input.mousePosition.y * 10);
        //log movement
        Debug.Log("X: " + transformPosition.x + " Y: " + transformPosition.y);
    }

    void OnCursor(InputValue value)
    {
        transformPosition = value.Get<Vector2>();
        Debug.Log("x" + transformPosition.x + "y" + transformPosition.y);
    }
}
