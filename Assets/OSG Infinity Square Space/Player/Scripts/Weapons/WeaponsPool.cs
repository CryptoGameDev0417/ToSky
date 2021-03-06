// Infinity Square/Space. The prototype of the game is open source. V1.0
// https://github.com/nvjob/Infinity-Square-Space
// #NVJOB Nicholas Veselov
// https://nvjob.pro
// MIT license (see License_NVJOB.txt)




using UnityEngine;
using System.Collections.Generic;



public class WeaponsPool : MonoBehaviour {
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    public List<Weapons> weaponsList = new List<Weapons>();

    //--------------

    static Transform stThisTransform;
    static int[] stNumberWeapons;
    static GameObject[][] stWeapons;
    

    
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        
    private void Awake()
    {
        //--------------

        stThisTransform = transform;
        AddObjectsToPool();

        //--------------
    }
    


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    


    private void AddObjectsToPool()
    {
        //--------------

        stNumberWeapons = new int[weaponsList.Count];
        stWeapons = new GameObject[weaponsList.Count][];

        //--------------

        for (int num = 0; num < weaponsList.Count; num++)
        {
            stNumberWeapons[num] = weaponsList[num].numberWeapons;
            stWeapons[num] = new GameObject[stNumberWeapons[num]];
            InstanInPool(weaponsList[num].weapon, stWeapons[num]);
        }

        //--------------
    }
    


    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    static private void InstanInPool(GameObject obj, GameObject[] objs)
    {
        //--------------

        for (int i = 0; i < objs.Length; i++)
        {
            objs[i] = Instantiate(obj);
            objs[i].SetActive(false);
            objs[i].transform.parent = stThisTransform;
        }
        
        //--------------
    }



    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    static public GameObject GiveWeapons(int num)
    {
        //--------------
        
        for (int i = 0; i < stNumberWeapons[num]; i++) if (!stWeapons[num][i].activeSelf) return stWeapons[num][i];
        return null;
        
        //--------------
    }



    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    static public void TakeWeapons(GameObject obj)
    {
        //--------------

        obj.SetActive(false);
        if (obj.transform.parent != stThisTransform) obj.transform.parent = stThisTransform;

        //--------------
    }



    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}









[System.Serializable]

public class Weapons
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



    public GameObject weapon;
    public int numberWeapons = 100;



    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
}
