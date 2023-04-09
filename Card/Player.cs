using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Entity
{
    private int Health;
    private int Mana;
    public static Player player;
    public HealtBar HealtBar;
    public GameObject DeathText;

    private void Awake()
    {
        player = this;
        Statistiques.PlayerHealth =  Statistiques.PlayerMaxHealth;
        Statistiques.Mana = 3;
        Health = Statistiques.PlayerHealth;
        Mana= Statistiques.Mana;
        HealtBar.SetMaxHealth(Statistiques.PlayerMaxHealth);
    }

   public void TakeMana(int ManaCost)
   {
        Mana -= ManaCost;
        
       
   }

    public override void TakeDamage(int Damage)
    {
        Debug.Log("la vie du joueur est" + Health);
        Health -= Damage;
        HealtBar.SetHealth(Health);
        if (ShouldDie())
        {
            Die();
        }
    }

    protected override bool ShouldDie()
    {
        return  Health <= 0;
    }
    protected override void Die()
    {
        Destroy(gameObject);
        Cards.CurrentlyDrag = null;
        DeathText.SetActive(true);
      
    }

    public static bool HasEnoughMana(int ManaCost)
    {
        Debug.Log("mana suffisant :" + (ManaCost <= player.Mana));
        Debug.Log("Mana :" + player.Mana);
        return ManaCost <= player.Mana;
    }


    public static void Reset()
    {
        player.Mana = 3;
    }
}
