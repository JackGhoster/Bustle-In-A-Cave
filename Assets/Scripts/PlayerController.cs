using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private PlayerControls playerControls;
    public Animator animator;
    
    //private bool isGoingUp = false;
    //private bool isGoingRight = false;

    private Vector2 MoveInputVector = Vector2.zero;
    private Vector2  ScreenBordersVector = new Vector2(1.1f, 0.5f);

    private float speedDivider = 100f;


    // Start is called before the first frame update
    private void Awake()
    {
        playerControls = new PlayerControls();
        animator = GetComponent<Animator>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Move(MoveInputVector);
        
    }


    private void InputContextReader(InputAction.CallbackContext context)
    {
        //Assignment of a two axis value of player's input to a Vector2 variable
        MoveInputVector = context.ReadValue<Vector2>();

        AnimationSwitcher();
    
        ////vertical movement bool assignment (can use it later)
        //isGoingUp = context.ReadValue<Vector2>().y >= 0.5f ? isGoingUp = true : isGoingUp = false;

        ////horizontal movement bool assignment (can use it later)
        //isGoingRight = context.ReadValue<Vector2>().x >= 0.5f ? isGoingRight = true : isGoingRight = false;
    }


    protected void Move(Vector2 InputVector)
    {
        if (InputVector == Vector2.zero) return;

        this.transform.Translate(InputVector / speedDivider);

        OnScreenBorderEnter();
    }


    private void OnScreenBorderEnter()
    {
        //Really sorry for the dirty code I was really lazy with this one

        //The Vector that's used later to return character back to the game area
        Vector2 ReturnerVector = Vector2.zero;

        //When trying to cross the upper border character is returning back down
        if (transform.position.y > ScreenBordersVector.y)
        {
            ReturnerVector = new(0, -0.01f);
            transform.Translate(ReturnerVector);
        }
        //When trying to cross the bottom border character is returning back up
        else if (transform.position.y < -ScreenBordersVector.y)
        {
            ReturnerVector = new(0, 0.01f);
            transform.Translate(ReturnerVector);
        }


        //When trying to cross the right border character is returning back to the left
        if (transform.position.x > ScreenBordersVector.x)
        {
            ReturnerVector = new(-0.01f, 0);
            transform.Translate(ReturnerVector);
        }
        //When trying to cross the left border character is returning back to the right
        else if (transform.position.x < -ScreenBordersVector.x)
        {
            ReturnerVector = new(0.01f, 0);
            transform.Translate(ReturnerVector);
        }
    }

    private void AnimationSwitcher()
    {
        animator.SetFloat("VerticalAxis", MoveInputVector.y);
        animator.SetFloat("HorizontalAxis", MoveInputVector.x);
    }


    private void OnEnable()
    {
        playerControls.Ground.Move.performed += InputContextReader;
        playerControls.Ground.Move.canceled += InputContextReader;
        playerControls.Enable();
        
    }

    private void OnDisable()
    {
        playerControls.Ground.Move.performed -= InputContextReader;
        playerControls.Disable();
    }

}
