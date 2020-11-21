using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Spell CurrentEffect;

    public float MoveSpeed;

    [SerializeField]
    int health;
    bool PhysicalStaggered;
    [SerializeField]
    int SpiritHealth;


    //Hit with physical damage.
    public void PhysicalHit(int damage){
        Debug.Log("Hit");
        health -= damage;
        if(health <= 0){
            PhysicalDeath();
        }
    }


    //When hit with spirit damage, needs to have the physical damage done first
    public void SpiritHit(int damage){
        if(PhysicalStaggered){
            SpiritHealth -= damage;
            if(SpiritHealth <= 0){
                SpiritDeath();
            }
        }

    }

    //The methods that happen for death, Probably should override for the player.

    //Happens when physical health runs out, allows player to do attack on spirit, Will probably be adding effects to the characters
    void PhysicalDeath(){
        PhysicalStaggered = true;
    }

    //Actual death, Needs to add effects. 
    void SpiritDeath(){
        Destroy(gameObject);
    }

}
