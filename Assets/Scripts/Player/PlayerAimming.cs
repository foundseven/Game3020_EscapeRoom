using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAimming : MonoBehaviour
{
    public Transform headPos;
    public MainCamera cameraTransform;
    public Image crosshairImage;
    public LayerMask aimLayerMask; // To filter the layers the raycast should interact with

    [SerializeField]
    AudioClip _clickSound;

    private void Start()
    {
        // Make sure the crosshair is enabled
        if (crosshairImage != null)
        {
            crosshairImage.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Detect left mouse button click
        {
            Debug.Log("Mouse click detected!"); // Verify mouse click input
        }
        

        // Raycast from the camera center using the main camera's position and forward direction
        Ray ray = new Ray(cameraTransform.transform.position, cameraTransform.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, aimLayerMask))
        {
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.yellow);
            UnityEngine.Debug.Log("Hit: " + hit.transform.name);

            float distance = Vector3.Distance(cameraTransform.transform.position, hit.point);
            if (distance <= 50f)
            {
                UnityEngine.Debug.Log("Distance check worked");
                if (Input.GetMouseButtonDown(0))
                {
                    SoundManager.instance.PlayAudioClip(_clickSound);
                    UnityEngine.Debug.Log("Mouse click detected on " + hit.transform.name);
                    if (hit.transform.GetComponent<KeypadKey>() != null)
                    {
                        hit.transform.GetComponent<KeypadKey>().SendKey();
                    }
                    else if (hit.transform.GetComponent<DoorController>() != null)
                    {
                        hit.transform.GetComponent<DoorController>().OpenLockedDoor();
                    }
                }
            }
        }
    }
}
