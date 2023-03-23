using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardObj : MonoBehaviour
{
    public CardSO cardData;
    [SerializeField] private List<Color> rarityColors = new List<Color>(5);

    [Header("Object Refs")]
    public Image border;
    public Image visuals;
    public TMP_Text nameLabel;
    public TMP_Text description;
    public TMP_Text damageLabel;
    public TMP_Text healthLabel;
    public GameObject unownedOverlay;

    public void Start()
    {
        InitializeButton();
        if (cardData) { BuildCard(); }
    }

    public void SetCardData(CardSO card)
    {
        cardData = card;
        BuildCard();
    }

    private void BuildCard()
    {
        SetBorderColor();
        visuals.sprite = cardData.sprite;
        nameLabel.text = cardData.title;
        description.text = cardData.description;
        healthLabel.text = cardData.health.ToString();
        damageLabel.text = cardData.power.ToString();
    }

    private void SetBorderColor()
    {
        border.color = rarityColors[(int)cardData.rarity];
    }

    public void ShowUnowned()
    {
        unownedOverlay.SetActive(true);
    }

    //============== handle click ==================
    private void InitializeButton()
    {
        GetComponent<Button>().onClick.AddListener(OnInspect);
    }

    private void OnInspect()
    {
        CardPopupManager.instance.ShowCardPopup(cardData);
    }
}
