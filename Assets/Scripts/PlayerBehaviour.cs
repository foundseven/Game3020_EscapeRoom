using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float _movementSpeed = 15.0f;

    private Rigidbody _rb;

    //public float _verticalInput;
    //public float _horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float _verticalInput = Input.GetAxis("Vertical") * _movementSpeed;
        float _horizontalInput = Input.GetAxis("Horizontal") * _movementSpeed;

        Vector3 _movement = new Vector3(_horizontalInput, 0.0f, _verticalInput);
        _rb.MovePosition(transform.position + _movement * Time.deltaTime);

    }
}
