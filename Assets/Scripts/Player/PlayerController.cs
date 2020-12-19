using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : CharacterController
{
    public bool IsIFrame { get; private set; }

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
            IsIFrame = true;
            Invoke("IFrames", 2);
        }
    }

    void IFrames()
    {
        IsIFrame = false;
    }
}