using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackroundOverlayScript : MonoBehaviour
{
    // Start is called before the first frame update
    Image image;
    void Start()
    {
        //set image color to red
        image = GetComponent<Image>();
        image.color = new Color(255, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //rainbow effect
        image.color = new Color(Mathf.Sin(Time.time), Mathf.Sin(Time.time + 2), Mathf.Sin(Time.time + 4));
    }
}
