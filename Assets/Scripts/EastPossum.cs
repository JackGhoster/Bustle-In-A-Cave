using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EastPossum : AbstractEnemy
{
    public override void Awake()
    {
        walkingAnimation = "Left";
        speedSetter = Random.Range(minSpeed, maxSpeed);
        MovementVector = Vector2.left;
        base.Awake();
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer();
    }
}
