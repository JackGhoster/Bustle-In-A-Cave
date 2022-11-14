using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SouthPossum : AbstractEnemy
{
    public override void Awake()
    {
        walkingAnimation = "Up";
        speedSetter = Random.Range(minSpeed, maxSpeed);
        MovementVector = Vector2.up;
        base.Awake();
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer();
    }
}
