using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckContentPanel : MonoBehaviour
{
    public GameObject collectionContent;
    public GameObject deckContent;

    public void ShowCollectionContent()
    {
        HideContent();
        collectionContent.SetActive(true);
    }

    public void ShowDeckContent()
    {
        HideContent();
        deckContent.SetActive(true);
    }

    private void HideContent()
    {
        collectionContent.SetActive(false);
        deckContent.SetActive(false);
    }
}
