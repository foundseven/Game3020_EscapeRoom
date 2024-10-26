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
    public bool isCameraLocked = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }
    // Update is called once per frame
    void Update()
    {
        if (isCameraLocked) return;

        _turn.x += Input.GetAxis("Mouse X");
        _turn.y += Input.GetAxis("Mouse Y");

        _turn.y = Mathf.Clamp(_turn.y, -_cameraPitchLimit, _cameraPitchLimit);
        transform.localRotation = Quaternion.Euler(-_turn.y, 0, 0);
    }
}
