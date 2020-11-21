using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    public GameObject Sword;
    public float SwordCooldown;
    bool  CanUseSword = true;

    public Transform ShootPoint;
    public GameObject Bullet;
    public float GunCooldown;
    bool CanFireGun = true;

    public Spell CurrentSpell;
    


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
            Instantiate(Bullet,ShootPoint.position,Quaternion.identity);
            Invoke("RefreshGun",GunCooldown);
        }

    }

    void RefreshGun(){
        CanFireGun = true;
    }


    void UseSpell(){
        
    }

}
