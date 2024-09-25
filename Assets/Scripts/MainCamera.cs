using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainCamera : MonoBehaviour
{
    //public Transform _player; 
    public GameObject _player;
    public Vector2 _turn;

    public float _cameraPitchLimit = 10f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    // Update is called once per frame
    void Update()
    {
        _turn.x += Input.GetAxis("Mouse X");
        _turn.y += Input.GetAxis("Mouse Y");

        _turn.y = Mathf.Clamp(_turn.y, -_cameraPitchLimit, _cameraPitchLimit);
        transform.localRotation = Quaternion.Euler(-_turn.y, 0, 0);
    }

    //public float sensX;
    //public float sensY;

    //public Transform orientation;

    //float xRotation;
    //float yRotation;

    //private void Start()
    //{
    //    Cursor.lockState = CursorLockMode.Locked;
    //    Cursor.visible = false;
    //}

    //private void Update()
    //{
    //    float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
    //    float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

    //    yRotation += mouseX;

    //    xRotation -= mouseY;

    //    xRotation = Mathf.Clamp(xRotation, -15f, 10f);

    //    transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    //    orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    //}
}
