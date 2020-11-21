using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Vector2 velocity;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(velocity*Time.deltaTime);
    }


    /*void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Character")){
            col.gameObject.GetComponent<CharacterController>().PhysicalHit(damage);
        }
    }*/

    void OnBecameInvisible(){
        Destroy(gameObject);
    }

    public void setVelocity(float f)
    {
        velocity = new Vector2(f, 0);
    }

    public Vector2 getVelocity()
    {
        return velocity;
    }
}
