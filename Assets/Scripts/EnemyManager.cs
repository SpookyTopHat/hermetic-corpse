using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * A library for storing basic enemy data.
 * credit to http://prof.johnpile.com/2014/07/20/globalprefabs/ for this alg, and for teaching me what hash codes are used for
 */

[System.Serializable]
public class EnemyManager : ScriptableObject
{
    public static Dictionary<int, GameObject> enemies = new Dictionary<int, GameObject>();
    private static bool isLoaded = false;
    /**
     * Loads enemy prefabs into memory, if they're not already loaded.
     */
    public static void LoadEnemies()
    {
        if (!isLoaded)
        {
            Object[] EnemyArray = Resources.LoadAll("Enemies");
            foreach (Object b in EnemyArray)
            {
                enemies.Add(b.name.GetHashCode(), (GameObject)b);
            }
            //Debug.Log("All bullets are loaded!");
            isLoaded = true;
        }
    }

    /**
     * Type in the name of the enemy, and this will return the GameObject copy in the dictionary.
     */
    public static GameObject getPrefab(string objName)
    {
        GameObject obj;
        if (enemies.TryGetValue(objName.GetHashCode(), out obj))
        {
            return obj;
        }
        else
        {
            Debug.Log("Object \"" + objName + "\" not found!");
            return (null);
        }
    }

}
