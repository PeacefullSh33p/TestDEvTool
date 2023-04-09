using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CardManagerWindow : EditorWindow
{

    [SerializeField] private int m_SelectedIndex = -1;
    private VisualElement rightPanel;
     static CardsScriptable cardScriptable;
    Texture2D headerSectiontextture;
    public static  CardsScriptable CardsScriptableInfo { get { return   cardScriptable; } }
    public int test;

    Rect headerSection;
   

    [MenuItem("Tools/CardEditor")]
    public static void ShowCardManagerWindow()
    {
        // This method is called when the user selects the menu item in the Editor
        EditorWindow wnd = GetWindow<CardManagerWindow>();
        wnd.titleContent = new GUIContent("CardEditor");

        wnd.minSize = new Vector2(450, 200);
        wnd.maxSize = new Vector2(1920, 720);
    }


    public void CreateGUI()
    {  
      
        rootVisualElement.Add(new Label("CardEditor"));
        // Get a list of all sprites in the project
        var allObjectGuids = Resources.LoadAll<Sprite>("Sprite");
        var allObjects = new List<Sprite>();

        foreach (Sprite obj in allObjectGuids)
        {
            allObjects.Add(obj);
        }

        var Twopanels = new TwoPaneSplitView(0, 250, TwoPaneSplitViewOrientation.Horizontal);
        rootVisualElement.Add(Twopanels);

        var leftPanel = new ListView();
        Twopanels.Add(leftPanel);


        leftPanel.makeItem = () => new Label();
        leftPanel.bindItem = (item, Index) => { (item as Label).text = allObjects[Index].name; };
        leftPanel.itemsSource = allObjects;
        leftPanel.onSelectionChange += OnSpriteSelectionChange;
        

       
        rightPanel = new ScrollView(ScrollViewMode.VerticalAndHorizontal); 
        Twopanels.Add(rightPanel);

        // Restore the selection index from before the hot reload
        leftPanel.selectedIndex = m_SelectedIndex;

        // Store the selection index when the selection changes
        leftPanel.onSelectionChange += (items) => { m_SelectedIndex = leftPanel.selectedIndex; };

        InitData();

        DrawLayouts();

        InitTextures();

        

    }
    public static void InitData()
    {
        cardScriptable = Resources.Load<CardsScriptable>("ScriptableObject/Cards/CardsDatas");
        cardScriptable = (CardsScriptable)ScriptableObject.CreateInstance(typeof(CardsScriptable));
    }

    private void OnGUI()
    {

      SetupRefs();
    }

    void InitTextures()
    {
        headerSectiontextture = new Texture2D(1, 1);
        headerSectiontextture.SetPixel(0, 0, Color.black);
        headerSectiontextture.Apply();
        

    }
    private void OnSpriteSelectionChange(IEnumerable<object> selectedItems)
    {
      rightPanel.Clear();

        var selectedSprite = selectedItems.First() as Sprite;

        if (selectedSprite == null)
        {
       
            return;
        }


        var spriteImage = new Image();
        spriteImage.scaleMode = ScaleMode.ScaleToFit;
        spriteImage.sprite = selectedSprite;
       // spriteImage.sprite.border = 5;
        rightPanel.Add(spriteImage);

        
        Button btn = new Button();
        rightPanel.Add(btn);
        btn.text = "Generate_Scriptable";
        btn.clicked += () => { MakeScriptableObject.CreateMyAsset(); };
        rightPanel.Add(btn);
     
    }

    /// <summary>
    /// Ci-dessous se trouve une fonction pour faire en sorte d'assigner les valeurs du scriptable a des intfield pour pouvoir les edits
    /// problème : je ne peux modifierla valeur de mes intfields.
    /// </summary>
    private void SetupRefs()
    {
        GUILayout.BeginArea(headerSection);

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Manacost");
        cardScriptable.ManaCost = EditorGUILayout.IntField(cardScriptable.ManaCost);
        EditorGUILayout.EndHorizontal();
      

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("MinManacost");
        cardScriptable.MinManaCost = EditorGUILayout.IntField(cardScriptable.MinManaCost);
        EditorGUILayout.EndHorizontal();


        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("MaxManacost");
        cardScriptable.MaxManaCost = EditorGUILayout.IntField(cardScriptable.MaxManaCost);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("MaxDamage");
        cardScriptable.MaxDamage = EditorGUILayout.IntField(cardScriptable.MaxDamage);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("MinDamage");
        cardScriptable.MinDamage = EditorGUILayout.IntField(cardScriptable.MinDamage);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Damage");
        cardScriptable.DMG = EditorGUILayout.IntField(cardScriptable.DMG);
        EditorGUILayout.EndHorizontal();

        GUILayout.EndArea();

    }

    void DrawLayouts()
    {
        headerSection.x = 0;
        headerSection.y = 500;
        headerSection.width = Screen.width;
        headerSection.height = 200;

        GUI.DrawTexture(headerSection, headerSectiontextture);
    }
   
}
