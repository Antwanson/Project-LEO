using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameCapping : MonoBehaviour
{
    public int frameRate = 60; // Desired frame rate
    // Start is called before the first frame update
    void Start()
    {
        //cap the frame rate to 60 fps
        Application.targetFrameRate = frameRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
