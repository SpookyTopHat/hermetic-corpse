using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Spell CurrentEffect;

    public float MoveSpeed;

    [SerializeField]
    int health;
    public bool isIFrame;

    public void setHealth(int health)
    {
        this.health = health;
    }

    public int getHealth()
    {
        return health;
    }

    
    //Hit with physical damage.
    public void PhysicalHit(int damage){

        health -= damage;

        if(health <= 0){
            PhysicalDeath();
        } else
        {
            StartCoroutine("IFrames", 2);
        }
    }

    private IEnumerator IFrames(float duration){
        isIFrame = true;
        yield return new WaitForSeconds(duration);
        isIFrame = false;
    }

    //The methods that happen for death, Probably should override for the player.

    //Happens when physical health runs out, allows player to do attack on spirit, Will probably be adding effects to the characters
    void PhysicalDeath(){
        Destroy(this.gameObject);
    }
}
