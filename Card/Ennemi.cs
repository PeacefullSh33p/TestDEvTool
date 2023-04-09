using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ennemi : Entity
{

    public static int Health;
    public static int DMG;
    public static int MinDMG;
    public static int MaxDMG;
    public static Sprite sprite;
    public static Ennemi ennemi;
    public SpriteRenderer spriteRenderer;
    public EnnemiManager ennemiManager;
    // Start is called before the first frame update
    private void Awake()
    {
        ennemiManager = FindObjectOfType<EnnemiManager>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        ennemiManager.Init(Random.Range(0, 2));
    }
    private void Start()
    {
        spriteRenderer.GetComponent<SpriteRenderer>().sprite = sprite;
    }
    public static void Attack()
    {
        Statistiques.PlayerHealth -= DMG;
    }

    protected override bool ShouldDie()
    { 
        return Health <= 0; // on retourne direct ennemiHealth puisqu' <= est un check.
    }
 
    public override void TakeDamage(int Damage)
    {
        Health -= Damage;
        if(ShouldDie())
        {
           Die();
        }
    }
        
   protected override void Die()
    {
        TurnHandler.EnnemisIsAlive= false;
        if(TurnHandler.EnnemisIsAlive == false)
        {
            ennemiManager.EnnemisArray.Remove(this);
            Destroy(gameObject);
            Debug.Log("L'ennemi est mort");
            Cards.CurrentlyDrag = null;
            ennemiManager.CurrentnumberOfEnnemy--;
        }
   }

    private void OnMouseDown()
    {
        if (Cards.CurrentlyDrag)
        {
            Debug.Log("Click Monstre + carte");
        }
    }
    private void OnMouseEnter()
    {
        ennemi = this;
    }

    private void OnMouseExit()
    {
        ennemi= null;
    }

    
    

}
