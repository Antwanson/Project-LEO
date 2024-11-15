using System.Collections;
using UnityEngine;

public class UIPolygonMove : MonoBehaviour
{
    void OnEnable()
    {
        foreach (RectTransform child in transform)
        {
            StartCoroutine(UpdateChildPos(child));
        }
    }
    private void OnDisable()
    {
        foreach (RectTransform child in transform)
        {
            StopCoroutine(UpdateChildPos(child));
        }
    }
    IEnumerator UpdateChildPos(RectTransform child)
    {
        Vector2 prePos = child.anchoredPosition;
        Vector2 fromPos = prePos;
        Vector2 targetPos = prePos + RandomOffset(30);
        float duration = 0.2f;
        float pastTime = 0;
        while (true)
        {
            pastTime += Time.deltaTime;
            if (pastTime >= duration)
            {
                fromPos = targetPos;
                targetPos = prePos + RandomOffset(30);
                pastTime = 0;
            }
            var t = pastTime / duration;
            child.anchoredPosition = Vector2.Lerp(fromPos, targetPos, t);
            yield return null;
        }
    }
    private Vector2 RandomOffset(float max)
    {
        return new Vector2(Random.Range(-max, max), Random.Range(-max, max));
    }
}