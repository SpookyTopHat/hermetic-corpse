using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
 * A library for loading and firing bullets.
 * credit to http://prof.johnpile.com/2014/07/20/globalprefabs/ for this alg, and for teaching me what hash codes are used for
 */

[System.Serializable]
public class BulletManager : ScriptableObject
{
    public static Dictionary<int, GameObject> bullets = new Dictionary<int, GameObject>();
    private static bool isLoaded = false;
    /**
     * Loads the bullets into memory, if they're not already loaded.
     */
    public static void LoadBullets()
    {
        if (!isLoaded)
        {
            Object[] BulletArray = Resources.LoadAll("Bullets");
            foreach (Object b in BulletArray)
            {
                bullets.Add(b.name.GetHashCode(), (GameObject)b);
            }
            //Debug.Log("All bullets are loaded!");
            isLoaded = true;
        }
    }

    /**
     * Type in the name of the bullet, and this will return the GameObject copy in the dictionary.
     */
    public static GameObject getPrefab(string objName)
    {
        GameObject obj;
        if (bullets.TryGetValue(objName.GetHashCode(), out obj))
        {
            return obj;
        }
        else
        {
            Debug.Log("Object \"" + objName + "\" not found!");
            return (null);
        }
    }

    /**
     * Fires a bullet prefab of the specified name, at the specified position, angle (in terms of rotation around the z-axis) and velocity.
     */
    public static void Fire(string bulletName, Vector2 pos, float zAngle, float vel)
    {
        GameObject bullet = getPrefab(bulletName);
        if (bullet != null && bullet.TryGetComponent(out BulletScript bs))
        {            
            GameObject cloon = Instantiate(bullet, pos, Quaternion.Euler(0, 0, zAngle)); //a clone of the prefab
            cloon.GetComponent<BulletScript>().setVelocity(vel);
        }
        else
        {
            Debug.Log("This object cannot be fired.");
        }
    }
}
