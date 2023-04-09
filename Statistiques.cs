using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StatistiquesScripableObject", order = 1)]
public class Statistiques : ScriptableObject
{
   

    [Header("Player Stats")]
    public static int PlayerHealth;
    public static int PlayerMaxHealth = 10;
    public static int ManaMax = 5;
    public static int Mana;

   


}
