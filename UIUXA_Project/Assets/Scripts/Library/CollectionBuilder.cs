using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollectionBuilder : MonoBehaviour
{
    [SerializeField] private bool setName = true;
    [SerializeField] private List<string> names;

    [Header("Card Settings")]
    [SerializeField] private CardSO[] cardDatas;
    [SerializeField] private GameObject cardPrefab;
    [SerializeField] private int minCards = 3, maxCards = 10;
    [SerializeField] private int maxCardsPerRow = 7;
    [SerializeField] private float ownedPercent = 0.5f;

    [Header("Refs")]
    [SerializeField] private TMP_Text nameLabel;
    [SerializeField] private RectTransform cardHolder;

    private RectTransform rt;

    private void Start()
    {
        rt = GetComponent<RectTransform>();
        if (setName) { SetupName(); }
        BuildCards();
    }

    private void SetupName()
    {
        nameLabel.text = names[Random.Range(0, names.Count)];
        names.Remove(nameLabel.text);
    }

    private void BuildCards()
    {
        int desiredCount = Random.Range(minCards, maxCards);
        ScaleCheck(desiredCount);
        for (int i = 0; i < desiredCount; i++) {
            GameObject gO = Instantiate(cardPrefab, cardHolder);
            //set card data
            CardObj card = gO.GetComponent<CardObj>();
            card.SetCardData(cardDatas[Random.Range(0, cardDatas.Length)]);
            //grey out maybe
            if (Random.Range(0f, 1f) > ownedPercent) {
                card.ShowUnowned();
            }
        }
    }

    private void ScaleCheck(int desiredAmount)
    {
        float incrementSize = rt.sizeDelta.y + cardHolder.sizeDelta.y + 25;
        while (desiredAmount > maxCardsPerRow) {
            rt.sizeDelta += new Vector2(0, incrementSize);
            desiredAmount -= maxCardsPerRow;
        }
    }
}
