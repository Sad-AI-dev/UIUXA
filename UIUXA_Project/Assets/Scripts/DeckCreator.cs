using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckCreator : MonoBehaviour
{
    [SerializeField] private GameObject deckTemplate;

    public void BuildDeckButton()
    {
        GameObject gO = Instantiate(deckTemplate, transform.parent);
        gO.transform.SetSiblingIndex(gO.transform.GetSiblingIndex() - 1);
    }
}
