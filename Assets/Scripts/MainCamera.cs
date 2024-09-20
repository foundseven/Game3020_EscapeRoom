using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MainCamera : MonoBehaviour
{
    public Transform _player; 
    public Vector3 _offset; //where we want the camera
    public float _smoothing = 0.3f; //reps the movement of the camera

    private Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void Update()
    {
        if (_player == null) return;

        // calculate the POS the camera wants to be at
        Vector3 targetPosition = _player.position + _offset;

        // move accordingly
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,
            ref velocity, _smoothing);
    }
}
