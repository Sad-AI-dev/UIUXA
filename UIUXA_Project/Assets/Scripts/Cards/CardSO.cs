using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Card", menuName = "ScriptableObjects/Card")]
public class CardSO : ScriptableObject
{
    public string title;
    public Sprite sprite;
    public string description;
    //stats...?
    public int power = 1;
    public int health = 1;
}
