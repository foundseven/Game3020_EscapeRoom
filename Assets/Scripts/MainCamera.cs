using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainCamera : MonoBehaviour
{
    //public Transform _player; 
    public GameObject _player;
    public Vector2 _turn;
    public Vector3 _offset; //where we want the camera
    public float _smoothing = 0.3f; //reps the movement of the camera

     void Start()
    {
        transform.position = new Vector3(20, 8, 15);
        _offset = transform.position - _player.transform.position;

        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void Update()
    {
        _turn.x += Input.GetAxis("Mouse X");
        _turn.y += Input.GetAxis("Mouse Y");

        transform.localRotation = Quaternion.Euler(-_turn.y, _turn.x, 0);

        transform.position = new Vector3(_player.transform.position.x + _offset.x, 
                                         _player.transform.position.y + _offset.y,
                                         _player.transform.position.z + _offset.z);
    }
}
