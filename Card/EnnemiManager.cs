using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiManager : MonoBehaviour
{
  
    public List<EnnemisDatas> Stats;
    public  List<Ennemi> EnnemisArray;
    public List<GameObject> SpawnpointsArray;
    public int NumberOfEnnemyToSpawn;
    public int CurrentnumberOfEnnemy;
    public bool SpawnPointOccuped;
    public GameObject EnnemyPrefab;
  
    // Start is called before the first frame update

    public void Awake()
    {
        CurrentnumberOfEnnemy = NumberOfEnnemyToSpawn;
        for (int i = 0; i != NumberOfEnnemyToSpawn; i++)
        {
            GameObject CurrentEnnemy= Instantiate(EnnemyPrefab);
            CurrentEnnemy.AddComponent<Ennemi>();
            SetLocation(CurrentEnnemy);
            EnnemisArray.Add(CurrentEnnemy.GetComponent<Ennemi>());
            

        }
       
    }


    void SetLocation(GameObject Ennemy)
    {
        List<int> AvailableIndexes= new List<int>();
        for(int i = 0; i < SpawnpointsArray.Count; i++) 
        {
            if (SpawnpointsArray[i].transform.childCount == 0)  // on check si l'index de la nouvelle liste est vide 
            {
                AvailableIndexes.Add(i);  // si oui on ajoute l'index du transform vide à la nouvelle liste
            }
        }

        int SelectedAvailableIndex = Random.Range(0, AvailableIndexes.Count); 
        int RandomSpawnPoint = AvailableIndexes[SelectedAvailableIndex]; // on fait un int permettant de récup non pas l'index mais sa valeur
        Ennemy.transform.parent = SpawnpointsArray[RandomSpawnPoint].transform;
        Ennemy.transform.position = SpawnpointsArray[RandomSpawnPoint].transform.position;

    }

    public void Init(int random)
    {   
            Ennemi.sprite = Stats[random].S_Renderer;
            Ennemi.DMG =  Random.Range(Stats[random].EnnemiMinDamage, Stats[random].EnnemiMaxDamage);
            Ennemi.MinDMG = Stats[random].EnnemiMinDamage;
            Ennemi.MaxDMG = Stats[random].EnnemiMaxDamage;      
    }

}
