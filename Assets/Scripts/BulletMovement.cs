using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Vector2 velocity;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log("moving...");
        transform.Translate(velocity*Time.deltaTime);
    }

    /*
     * Shoots a bullet at the desired velocity at the desired position. 
     */
    public static void fire(BulletMovement bulletPrefab, Vector2 pos, Vector2 vel)
    {
        Instantiate(bulletPrefab, pos, Quaternion.LookRotation(vel)).velocity = vel;
    }
}
