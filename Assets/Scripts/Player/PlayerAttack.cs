using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Sword;
    public float SwordCooldown;
    bool  CanUseSword = true;

    public Transform ShootPoint;
    public float GunCooldown;
    bool CanFireGun = true;

    public Spell CurrentSpell;

    private void Awake()
    {
        BulletManager.LoadBullets(); //loads both the player's bullets and the enemies' bullets into memory, if they're not already in there.
        //This is probably a suboptimal place to call it, and I'll be calling this from wave management scripts as well, *just in case*
        CanFireGun = true;
         //should refer to the player's hitbox
    }


    // Update is called once per frame
    void Update()
    {

        if(Input.GetAxis("Fire1") != 0){
            UseSword();
        }
        if(Input.GetAxis("Fire2") != 0){
            FireGun();
        }
        if(Input.GetAxis("Fire3") != 0){
            UseSpell();
        }


    }

    void UseSword(){
        if(CanUseSword){
            CanUseSword = false;
            Invoke("RefreshSword",SwordCooldown);
        }
    }

    void RefreshSword(){
        CanUseSword = true;
    }



    void FireGun(){
        if(CanFireGun){
            CanFireGun = false;
            BulletManager.Fire("Player_Bullet", ShootPoint.position, 90f, 20);
            Invoke("RefreshGun",GunCooldown);
        }
    }

    void RefreshGun(){
        CanFireGun = true;
    }


    void UseSpell(){
        
    }

}
