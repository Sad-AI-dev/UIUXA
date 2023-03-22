using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card")]
public class CardSO : ScriptableObject
{
    public enum Rarity { common, uncommon, rare, epic, legendary }

    public Rarity rarity;
    public string title;
    public Sprite sprite;
    [TextArea]
    public string description;
    [Space(10)]
    //stats...?
    public int power = 1;
    public int health = 1;
}
