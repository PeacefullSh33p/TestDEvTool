using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class TurnHandler : MonoBehaviour
{
    public CardsManager cardsManager;
    public Statistiques Stats;
    public List<EnnemisDatas> ennemisDatas;
    public Turns GamePhase = Turns.StartPlayerPhase;
    public static bool WantSkipTurn= false;
    public static bool DestroyCards = false;
    public static bool EnnemisIsAlive = true;
    public EnnemiManager ennemiManager;
    public enum  Turns
    {
       StartPlayerPhase, LoopPlayerPhase,EndPlayerPhase,StartEnnemiPhase,LoopEnnemyPhase,EndEnnemyPhase
    }

    private void Awake()
    {
        ennemiManager = FindObjectOfType<EnnemiManager>();
        ennemisDatas = ennemiManager.Stats;
    }
    private void Update()
    {
        CheckTurn();
    }
    void CheckTurn()
    {
        switch(GamePhase)
        {
           case Turns.StartPlayerPhase:
                Startplayer();
                GamePhase= Turns.LoopPlayerPhase;
                break;

           case Turns.LoopPlayerPhase:
                if(WantSkipTurn)
                {
                    GamePhase= Turns.EndPlayerPhase;
                    WantSkipTurn = false;
                }
                break;

           case Turns.EndPlayerPhase:
                cardsManager.DestroyedCards(DestroyCards);                           
                GamePhase = Turns.StartEnnemiPhase; 
                break;

            case Turns.StartEnnemiPhase:
                GamePhase = Turns.LoopEnnemyPhase; break;

            case Turns.LoopEnnemyPhase:    
                if(EnnemisIsAlive)
                {
                       for(int i = 0; i!= ennemiManager.CurrentnumberOfEnnemy;i++)
                       {
                        Player.player.TakeDamage(Ennemi.DMG);

                       }

                  

                }
                 GamePhase = Turns.EndEnnemyPhase;
                break;

            case Turns.EndEnnemyPhase:
                GamePhase = Turns.StartPlayerPhase; break;

         
        }
    }
  
    void Startplayer()
    {
        Player.Reset();
        cardsManager.SpawnCards();
        GamePhase= Turns.LoopPlayerPhase;
    }

}


