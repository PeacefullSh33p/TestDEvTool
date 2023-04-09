using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataEnnemis", menuName = "ScriptableObjects/Ennemis", order = 3)]
public class EnnemisDatas : ScriptableObject
{

    [Header("Ennemi Stats")]
    public Sprite S_Renderer;
    public int EnnemiHealth;
    public int EnnemiDMG;
    public int EnnemiMinDamage;
    public int EnnemiMaxDamage;
    public EnnemiManager EnnemiManager;
    public List<GameObject> EnnemyToSpawn;
}
