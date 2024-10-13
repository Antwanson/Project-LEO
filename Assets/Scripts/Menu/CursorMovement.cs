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
    [SerializeField]
    public int puckSpeedMultiplier = 10;

    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        playerControls = new CharacterControls();
    }

    // Update is called once per frame
    void Update()
    {
        // rectTransform.anchoredPosition = new Vector2(Input.mousePosition.x * 10, Input.mousePosition.y * 10);
        //log movement
        rectTransform.position = new Vector3(transformPosition.x * puckSpeedMultiplier + rectTransform.position.x, rectTransform.position.y + transformPosition.y * puckSpeedMultiplier, rectTransform.position.z);
        Debug.Log("X: " + transformPosition.x + " Y: " + transformPosition.y);
    }

    void OnCursor(InputValue value)
    {
        transformPosition = value.Get<Vector2>();
        Debug.Log("x" + transformPosition.x + "y" + transformPosition.y);
    }
}
