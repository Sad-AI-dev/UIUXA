using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWindowManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> windows;

    //vars
    GameObject currentWindow;
    Stack<GameObject> windowStack;

    private void Start()
    {
        HideWindows();
        //initialize vars
        windows[0].SetActive(true);
        currentWindow = windows[0];
        windowStack = new Stack<GameObject>(new[] { windows[0] });
    }

    //--------------got to new screen--------------
    public void SwitchToSubScreen(GameObject target)
    {
        SetWindowActive(target);
        windowStack.Push(currentWindow);
        currentWindow = target;
    }

    public void ReturnToLastScreen()
    {
        SetWindowActive(windowStack.Peek());
        if (windowStack.Count > 1) { windowStack.Pop(); }
        currentWindow = windowStack.Peek();

    }

    //------------switch screen--------------
    private void SetWindowActive(GameObject target)
    {
        if (windows.Contains(target)) {
            HideWindows();
            windows[windows.IndexOf(target)].SetActive(true);
        }
    }

    private void HideWindows()
    {
        foreach (GameObject window in windows) {
            if (window.activeSelf) {
                window.SetActive(false);
            }
        }
    }
}
