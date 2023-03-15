using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPathFollowerRE : MonoBehaviour
{
    //settings
    [Header("movement settings")]
    public float moveSpeed = 1f;
    public bool doLerp = false;

    [Header("path settings")]
    [SerializeField] private int startIndex = 0;
    public List<RectTransform> path;

    //vars
    private RectTransform rt;
    //private int currentPathIndex;
    private int targetIndex;
    //states
    private bool moving;

    private void Start()
    {
        //var checks
        if (path == null || path.Count <= 0) { Debug.LogError("Please assign a UI path"); }
        rt = GetComponent<RectTransform>();
        if (rt == null) { Debug.LogError("No target Rect Transform found"); }
        //start index
        rt.anchoredPosition = path[startIndex].anchoredPosition;
        targetIndex = startIndex;
    }

    public void MoveToNextPoint()
    {
        moving = true;
        targetIndex++;
        if (!IsTargetInRange()) { 
            targetIndex = 0;
            rt.anchoredPosition = path[targetIndex].anchoredPosition;
            moving = false;
        }
    }

    public void MoveToPreviousPoint()
    {
        moving = true;
        targetIndex--;
        if (!IsTargetInRange()) { 
            targetIndex = path.Count - 1;
            rt.anchoredPosition = path[targetIndex].anchoredPosition;
            moving = false;
        }
    }

    private bool IsTargetInRange()
    {
        return targetIndex >= 0 && targetIndex < path.Count;
    }

    //----------movement-----------
    private void Update()
    {
        if (moving) { Move(); }
    }

    private void Move()
    {
        Vector2 targetPos = path[targetIndex].anchoredPosition;
        MoveTowardsTarget(targetPos);
        HandleReachPoint(targetPos);
    }

    private void MoveTowardsTarget(Vector2 targetPos)
    {
        if (doLerp) {
            rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, targetPos, moveSpeed * Time.deltaTime);
        }
        else {
            rt.anchoredPosition = Vector2.MoveTowards(rt.anchoredPosition, targetPos, moveSpeed * 100 * Time.deltaTime);
        }
    }

    private void HandleReachPoint(Vector2 targetPos)
    {
        if (Vector2.Distance(rt.anchoredPosition, targetPos) < 0.1f) {
            rt.anchoredPosition = targetPos; //set pos
            //stop moving
            moving = false;
        }
    }
}
