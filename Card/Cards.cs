using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class Cards : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler 
{
    public CardsManager C_Manager;
    public RectTransform m_RectTransform;
    public Canvas m_Canvas;
    Vector3 initPos;
    private bool Drag = false;
    public static Cards CurrentlyDrag;
    public Sprite sprite;
    public Image image;

    private void Awake()
    {
        C_Manager = FindObjectOfType<CardsManager>();
        m_RectTransform = GetComponent<RectTransform>();
        m_Canvas = FindObjectOfType<Canvas>();
        initPos = m_RectTransform.position;
        sprite = C_Manager.Stats[C_Manager.chooseScriptable].Sprite;
        image= GetComponent<Image>();
        image.GetComponent<Image>().sprite= sprite;
    }

    


    public void Fight()
    {
        Ennemi.ennemi.TakeDamage(C_Manager.Stats[C_Manager.chooseScriptable].DMG);
        Player.player.TakeMana(C_Manager.Stats[C_Manager.chooseScriptable].ManaCost);
        C_Manager.CardsArray.Remove(this.gameObject);
        Destroy(this.gameObject);  

    }

    public void OnDrag(PointerEventData eventData)
    {
        if(Drag)
        {
            m_RectTransform.anchoredPosition += eventData.delta / m_Canvas.scaleFactor;  
            CurrentlyDrag = this;


        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!Drag) // élimination des cas chiants 
        {
            return;
        }
        Drag = false; // reset du drag
        if(Ennemi.ennemi == null)
        {
            m_RectTransform.position = initPos;
        }
        else
        {
            //... validation  quand j'ai la bonne carte & le bon monstre
            Fight();
        }
        CurrentlyDrag= null;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Player.HasEnoughMana(C_Manager.Stats[C_Manager.chooseScriptable].ManaCost))
        {
            Drag = true;
            initPos = m_RectTransform.position;
            Debug.Log("Je Drag l'item");

        }
       
        
    }



}
