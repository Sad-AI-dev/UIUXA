using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        //auto reset...?
        if (TryGetComponent(out Button btn)) {
            btn.onClick.AddListener(ScaleToMin);
        }
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
        if (Vector2.Distance(rt.localScale, targetScale) < 0.01f) { scaling = false; }
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
