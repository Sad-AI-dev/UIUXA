using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField] private float scaleSpeed;
    [SerializeField] private Vector2 maxScale;
    private Vector2 minScale;
    private Vector2 targetScale;

    private RectTransform rt;
    private bool scaling;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        minScale = rt.localScale;
    }

    private void Update()
    {
        if (scaling) {
            ScaleToTarget();
        }
    }

    private void ScaleToTarget()
    {
        rt.localScale = Vector2.MoveTowards(rt.localScale, targetScale, scaleSpeed * Time.deltaTime);
        if (Vector2.Distance(rt.localScale, targetScale) < 0.1f) { scaling = false; }
    }

    public void ScaleToMax()
    {
        scaling = true;
        targetScale = maxScale;
    }

    public void ScaleToMin()
    {
        scaling = true;
        targetScale = minScale;
    }
}
