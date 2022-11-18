using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NorthPossum : AbstractEnemy
{
    public override void Awake()
    {
        walkingAnimation = "Down";
        speedSetter = Random.Range(minSpeed, maxSpeed);
        MovementVector = Vector2.down;
        base.Awake();
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer();
    }
}
