using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    public PickupItem _pickupRef;

    private Rigidbody _rb;

    public float _movementSpeed = 50.0f;
    public float _jumpForce;

    private bool isGrounded;
    private bool isItemOverlapping = false;

    //refs
    public MainCamera cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotatePlayer();

        PickupOverlap();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded)
            {
                Jump();
            }
        }
    }

    void Move()
    {
        //get input for wasd
        float _verticalInput = Input.GetAxis("Vertical") * _movementSpeed;
        float _horizontalInput = Input.GetAxis("Horizontal") * _movementSpeed;

        //creating the movement vec relative to where the plahyer is facing
        Vector3 forwardMovement = transform.forward * _verticalInput * _movementSpeed;
        Vector3 rightMovement = transform.right * _horizontalInput * _movementSpeed;

        //mine
        // Vector3 _movement = new Vector3(_horizontalInput, 0.0f, _verticalInput);
        Vector3 _movement = (forwardMovement + rightMovement) * Time.deltaTime;
        _rb.MovePosition(transform.position + _movement);

    }

    //fix this similar to movement
    void Jump()
    {
        Vector3 jumpDirection = transform.up * _jumpForce;
        _rb.AddForce(jumpDirection, ForceMode.Impulse);
        isGrounded = false;
    }
    void RotatePlayer()
    {
        float cameraYaw = cameraTransform._turn.x;
        Quaternion newRotation = Quaternion.Euler(0, cameraYaw, 0);
        _rb.MoveRotation(newRotation);
    }

    void PickupOverlap()
    {
        if(isItemOverlapping && Input.GetKey(KeyCode.E))
        {
            _pickupRef.DestroyItem();
        }
    }

    //works but need it so when i click it and i am in the trigger box
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            isItemOverlapping = true;
        }
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
