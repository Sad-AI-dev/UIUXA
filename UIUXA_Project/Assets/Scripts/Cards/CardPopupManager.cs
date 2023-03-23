using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPopupManager : MonoBehaviour
{
    private void Awake()
    {
        if (instance != null && instance != this) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
    }
    public static CardPopupManager instance;

    public ActiveWindowManager windowManager;
    public GameObject cardPopup;
    public CardObj targetCard;

    public void ShowCardPopup(CardSO cardData)
    {
        windowManager.OpenPopup(cardPopup);
        targetCard.SetCardData(cardData);
    }
}
