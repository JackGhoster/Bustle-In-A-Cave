using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    private PlayerControls playerControls;
    public Animator animator;
    private bool isGoingUp = false;
    private bool isGoingRight = false;

    private Vector2 MoveVector = Vector2.zero;

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
        
    }


    private void Move(InputAction.CallbackContext context)
    {
        ////vertical movement bool assignment (can use it later)
        //isGoingUp = .y >= 0.5f ? isGoingUp = true : isGoingUp = false;

        ////horizontal movement bool assignment (can use it later)
        //isGoingRight = context.ReadValue<Vector2>().x >= 0.5f ? isGoingRight = true : isGoingRight = false;

        //Assignment of a two axis value of players input to a 
        MoveVector = context.ReadValue<Vector2>();

        AnimationSwitcher();
    }

    private void AnimationSwitcher()
    {
        animator.SetFloat("VerticalAxis", MoveVector.y);
        animator.SetFloat("HorizontalAxis", MoveVector.x);
        //didnt work as intended, it's too complicating to switch beetwen them with 2 bools
        //animator.SetBool("isGoingUp", isGoingUp);
        //animator.SetBool("isGoingRight", isGoingRight);
    }


    private void OnEnable()
    {
        playerControls.Ground.Move.performed += Move;
        playerControls.Ground.Move.canceled += Move;
        playerControls.Enable();
        
    }

    private void OnDisable()
    {
        playerControls.Ground.Move.performed -= Move;
        playerControls.Disable();
    }

}
