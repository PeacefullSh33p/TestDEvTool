using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MakeScriptableObject : MonoBehaviour
{
    [MenuItem("Assets/Create/NewScriptable")]
    public static void CreateMyAsset()
    {
         CardsScriptable asset = ScriptableObject.CreateInstance<CardsScriptable>();

        AssetDatabase.CreateAsset(asset, "Assets/NewScripableObject.asset");
        AssetDatabase.SaveAssets();

        EditorUtility.FocusProjectWindow();

        Selection.activeObject = asset;
    }
}
