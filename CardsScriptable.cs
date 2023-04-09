using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DataCards", menuName = "ScriptableObjects/Cards", order = 2)]
public class CardsScriptable : ScriptableObject
{
    [Header("Cards Stats")]
    public Sprite Sprite;
    public int DMG;
    public int MinDamage = 1;
    public int MaxDamage = 5;
    public int MinManaCost = 0;
    public int ManaCost;
    public int MaxManaCost = 3;
    
}
