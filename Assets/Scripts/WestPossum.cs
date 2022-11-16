using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WestPossum : AbstractEnemy
{
    public override void Awake()
    {
        walkingAnimation = "Right";
        speedSetter = Random.Range(minSpeed, maxSpeed);
        MovementVector = Vector2.right;
        base.Awake();
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer();
    }
}
