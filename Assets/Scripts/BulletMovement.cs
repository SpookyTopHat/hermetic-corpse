using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A basic, no-frills bullet movement simulator. 
 * Moves at a constant velocity.
 * If we want more complex movement, we'll have to use class inheritance.
 */
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
        transform.Translate(velocity*Time.deltaTime);
        //transform.eulerAngles = new Vector3(0,0, Mathf.radMathf.Atan2(velocity.y, velocity.x));
    }

    /*
     * Shoots a bullet at the desired velocity at the desired position. 
     */
    public static void fire(GameObject bulletPrefab, Vector2 position, Vector2 newVelocity)
    {
        GameObject p = Instantiate(bulletPrefab, position, Quaternion.identity);
        p.GetComponent<BulletMovement>().velocity = newVelocity;
    }
}
