using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{


    public float BulletSpeed;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(new Vector3(0,1*BulletSpeed * Time.fixedDeltaTime,0));
    }


    void OnCollisionEnter(Collision col){
        if(col.gameObject.CompareTag("Character")){
            col.gameObject.GetComponent<CharacterController>().PhysicalHit(damage);
        }
    }

    void OnBecameInvisible(){
        Destroy(gameObject);
    }


}
