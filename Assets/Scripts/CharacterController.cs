using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Spell CurrentEffect;

    public float MoveSpeed;

    [SerializeField]
    int health;

    public void setHealth(int health)
    {
        this.health = health;
    }

    public int getHealth()
    {
        return health;
    }

    
    //Hit with physical damage.
    public virtual void PhysicalHit(int damage){

        health -= damage;

        if(health <= 0){
            PhysicalDeath();
        }
    }

    //The methods that happen for death, Probably should override for the player.

    //Happens when physical health runs out, allows player to do attack on spirit, Will probably be adding effects to the characters
    public void PhysicalDeath(){
        Destroy(this.gameObject);
    }
}
