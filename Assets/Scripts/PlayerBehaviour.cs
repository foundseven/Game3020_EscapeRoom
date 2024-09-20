using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    private Rigidbody _rb;

    public float _movementSpeed = 50.0f;
    public float _jumpForce;

    private bool isGrounded;

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
        float _verticalInput = Input.GetAxis("Vertical") * _movementSpeed;
        float _horizontalInput = Input.GetAxis("Horizontal") * _movementSpeed;

        Vector3 _movement = new Vector3(_horizontalInput, 0.0f, _verticalInput);
        _rb.MovePosition(transform.position + _movement * Time.deltaTime);

    }

    void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        isGrounded = false;
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
