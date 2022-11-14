using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour
{
    //setting the walking animation base string, so I can choose the animations depending on the spawner(north,south,west,east)
    protected string walkingAnimation;

    //since the sprites are small I divide the vector 2 value by this random speed setter variable
    protected float minSpeed = 70f;
    protected float maxSpeed = 100f;
    protected float speedSetter;

    //setting the movement base vector, so I can choose the direction depending on the spawner(north,south,west,east)
    protected Vector2 MovementVector;
   
    //player's transform/pos (just in case, I don't actually use it right now, but in case I will, it's ready to be used c:)
    public Transform player;
    protected Vector2 playerPos;

    protected Animator animator;

    public virtual void Awake()
    {
        animator = GetComponent<Animator>();

        //actually getting the transform and the position of the player
        player = GameObject.Find("Player").transform;
        playerPos = player.transform.position;
        AnimationSetter();
    }

    public virtual void MoveTowardsPlayer()
    {
        //moving 
        this.transform.Translate(MovementVector / speedSetter);
    }

    public virtual void AnimationSetter()
    {
        animator.Play(walkingAnimation);
    }

}
