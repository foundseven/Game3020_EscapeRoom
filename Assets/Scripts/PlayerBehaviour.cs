using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody _rb;

    public float _movementSpeed = 50.0f;
    public float _jumpForce;

    private bool isGrounded;

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

        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    if(isGrounded)
        //    {
        //        Jump();
        //    }
        //}
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
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

    void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        isGrounded = false;
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
