using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class ScrollViewInitializer : MonoBehaviour
{
    private Scrollbar scrollbar;

    private void Awake()
    {
        scrollbar = GetComponent<Scrollbar>();
    }

    private void OnEnable()
    {
        StartCoroutine(EnableCo());
    }
    private IEnumerator EnableCo()
    {
        yield return null;
        scrollbar.value = 1f;
    }
}
