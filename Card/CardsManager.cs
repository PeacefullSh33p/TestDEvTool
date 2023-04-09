using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CardsManager : MonoBehaviour
{
    public  List<CardsScriptable> Stats;
    public GameObject LayoutCards;
    public  List<GameObject> CardsArray;
    public int NumbersOfCardsToSpawn;
    public GameObject CardsToSpawnPref;
    public int chooseScriptable;

    private void Awake()
    {
        chooseScriptable = Random.Range(0, Stats.Count);
    }

    public void SpawnCards()
    {
       
        for (int i = 0; i < NumbersOfCardsToSpawn; i++)
        {
            GameObject CurrentCard = Instantiate(CardsToSpawnPref, LayoutCards.transform);
            CurrentCard.AddComponent<Cards>();
            CardsArray.Add(CurrentCard);       
            
            
        }
        AddRandomValues();
    }
    
    public  bool DestroyedCards(bool DestroydeCard)
    {
        if (DestroydeCard == true)
        {
            foreach(GameObject Card in CardsArray)
            {
                Destroy(Card);
               CardsArray.Remove(Card);
            }
           
        }
        return DestroydeCard;
    }

    void AddRandomValues()
    {
       

        Stats[chooseScriptable].DMG = Random.Range(Stats[chooseScriptable].MinDamage, Stats[chooseScriptable].MaxDamage);
        Stats[chooseScriptable].ManaCost = Random.Range(Stats[chooseScriptable].MinManaCost, Stats[chooseScriptable].MaxManaCost);
        
    }
}

