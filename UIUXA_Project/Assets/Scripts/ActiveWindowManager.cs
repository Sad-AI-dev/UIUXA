using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWindowManager : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject startWindow;

    //vars
    private GameObject currentWindow;
    private Stack<GameObject> windowStack;

    private void Start()
    {
        HideAllWindows();
        //initialize vars
        startWindow.SetActive(true);
        currentWindow = startWindow;
        windowStack = new Stack<GameObject>(new[] { startWindow });
    }

    //--------------got to new screen--------------
    public void SwitchToSubScreen(GameObject target)
    {
        SetWindowActive(target);
        windowStack.Push(target);
        currentWindow = target;
    }
    public void OpenPopup(GameObject popup)
    {
        popup.SetActive(true);
        windowStack.Push(popup);
        currentWindow = popup;
    }

    public void ReturnToLastScreen()
    {
        if (windowStack.Count > 1) { windowStack.Pop(); }
        SetWindowActive(windowStack.Peek());
        currentWindow = windowStack.Peek();
    }

    //------------switch screen--------------
    private void SetWindowActive(GameObject target)
    {
        HideLastWindow();
        target.SetActive(true);
    }

    private void HideLastWindow()
    {
        currentWindow.SetActive(false);
    }

    //----------hide all screens-------
    private void HideAllWindows()
    {
        foreach (Transform t in canvas.transform) {
            t.gameObject.SetActive(false);
        }
    }
}
