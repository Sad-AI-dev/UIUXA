using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardObj : MonoBehaviour
{
    public CardSO cardData;

    [Header("Object Refs")]
    public Image visuals;
    public TMP_Text nameLabel;
    public TMP_Text description;
    public TMP_Text damageLabel;
    public TMP_Text healthLabel;
    public GameObject unownedOverlay;

    public void Start()
    {
        if (cardData) { BuildCard(); }
    }

    public void SetCardData(CardSO card)
    {
        cardData = card;
        BuildCard();
    }

    private void BuildCard()
    {
        visuals.sprite = cardData.sprite;
        nameLabel.text = cardData.title;
        description.text = cardData.description;
        healthLabel.text = cardData.health.ToString();
        damageLabel.text = cardData.power.ToString();
    }

    public void ShowUnowned()
    {
        unownedOverlay.SetActive(true);
    }
}
