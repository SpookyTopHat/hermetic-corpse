using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    public bool isIFrame;

    private void Start()
    {
        MoveSpeed = 5;
        setHealth(3);
    }

    public override void PhysicalHit(int damage)
    {

        setHealth(getHealth()-damage);

        if (getHealth() <= 0)
        {
            PhysicalDeath();
        }
        else
        {
            isIFrame = true;
            Invoke("IFrames", 2);
        }
    }

    void IFrames()
    {
        isIFrame = false;
    }
}