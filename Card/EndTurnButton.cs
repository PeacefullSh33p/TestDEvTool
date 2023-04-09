using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButton : MonoBehaviour
{
   
  public  void SetEnnemyTurn()
  {
        TurnHandler.WantSkipTurn = true;
  }

    public  void SetDestroyCards()
    {
       TurnHandler.DestroyCards = true;
    }
  
}
