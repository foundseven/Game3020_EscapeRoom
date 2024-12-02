using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour 
{
    public enum Animation 
    {
        IDLE,
        RUNNING,
        JUMPING,
        PUSHING
    }
}

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    public PickupItem _pickupRef;

    private Rigidbody _rb;

    public float _movementSpeed = 10.0f;
    public float _jumpForce;
    public float groundDrag;

    private bool isGrounded;
    bool grounded;
    public bool isInputLocked = false;

    public float playerHeight;
    public LayerMask whatIsGround;

    float _verticalInput;
    float _horizontalInput;

    Vector3 moveDirection;
    public Transform orientation;
    //refs
    public MainCamera cameraTransform;

    [SerializeField]
    public PauseMenu pauseMenu;

    [SerializeField]
    AudioClip _walkingSound, _jumpSound, _buttonClick;

    //animations
    private CharacterController _characterController;
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _rb.freezeRotation = true;
        isGrounded = true;
    }

    private void Awake()
    {
        pauseMenu = GameObject.FindObjectOfType<PauseMenu>(true);
    }
    // Update is called once per frame
    void Update()
    {
        if (isInputLocked) return;

        //ground check
        CheckIfGrouded();

        //handle the drag
        if(grounded)
        {
            _rb.drag = groundDrag;
           // UnityEngine.Debug.Log("Is Grounded");
        }
        else
        {
            //UnityEngine.Debug.Log("Is Not Grounded");
            _rb.drag = 0;
        }

        TogglePause();

        MyInput();

        SpeedControl();

        RotatePlayer();

        if(Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            UnityEngine.Debug.Log("Quitting Game");
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void MyInput()
    {
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
    }
    void Move()
    {
        moveDirection = orientation.forward * _verticalInput + orientation.right * _horizontalInput;

        _rb.AddForce(moveDirection.normalized * _movementSpeed, ForceMode.Force);

        //animation based on movement
        bool isMoving = _horizontalInput != 0 || _verticalInput != 0;
        _animator.SetBool("isRunning", isMoving);
        if(isMoving ) 
        {
           //needs to play once wait play again
           //SoundManager.instance.PlayAudioClip(_walkingSound);
        }
    }

    void TogglePause()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseMenu.TogglePauseMenu();
            SoundManager.instance.PlayAudioClip(_buttonClick);
        }
    }

    public void OpeningDoorAnimation()
    {
        _animator.SetBool("isPushing", true);
    }
    public void StopOpeningDoorAnimation()
    {
        _animator.SetBool("isPushing", false);
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(_rb.velocity.x, 0.0f, _rb.velocity.z);

        //limit the vel if needed
        if(flatVel.magnitude > _movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * _movementSpeed;
            _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
        }
    }

    void CheckIfGrouded()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);
        
        if(grounded) 
        {
            _animator.SetBool("isJumping", false);
        }
    }
    void Jump()
    {
        Vector3 jumpDirection = transform.up * _jumpForce;
        _rb.AddForce(jumpDirection, ForceMode.Impulse);
        grounded = false;

        //anim
        _animator.SetBool("isJumping", true);

        SoundManager.instance.PlayAudioClip(_jumpSound);

    }
    void RotatePlayer()
    {
        float cameraYaw = cameraTransform._turn.x;
        Quaternion newRotation = Quaternion.Euler(0, cameraYaw, 0);
        _rb.MoveRotation(newRotation);
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision with: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
