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
        GunCooldown = 0.1f;
        CanFireGun = true;
        ShootPoint = transform.GetChild(0); //should refer to the player's hitbox
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

    void RefreshGSword(){
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
