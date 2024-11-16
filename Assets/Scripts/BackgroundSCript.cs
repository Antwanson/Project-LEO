using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSCript : MonoBehaviour
{
    public SpriteRenderer backgroundSprite;
    public Color color1 = Color.blue;
    public Color color2 = Color.red; 
    public float duration = 3.0f;        // Time in seconds for one full cycle (blue to red and back to blue)

    private float timeElapsed;
    // Start is called before the first frame update
    void Start()
    {
        if(backgroundSprite == null){
            backgroundSprite = GetComponent<SpriteRenderer>(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        float t = Mathf.PingPong(timeElapsed / duration, 1f);
        backgroundSprite.color = Color.Lerp(color1, color2, t);
    }
}
