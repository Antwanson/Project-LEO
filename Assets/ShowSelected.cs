using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowSelected : MonoBehaviour
{
    public GameObject targetObject;

    private void Start()
    {
        DeactivateObject();
    }

    public void ActivateObject()
    {
        targetObject.SetActive(true);
    }

    public void DeactivateObject()
    {
        targetObject.SetActive(false);
    }
}
