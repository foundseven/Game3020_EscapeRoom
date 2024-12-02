using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public static DoorController Instance;

    [SerializeField] 
    public Vector3 openRotationOffset = new Vector3(0, -90, 0);
    [SerializeField] 
    public float openSpeed = 5f;
    [SerializeField]
    AudioClip _openDoorSound;

    private Quaternion closeRotation;
    private Quaternion openRotation;
    private bool isOpening = false;

    public bool lockedByPassword;
    private bool isUnlocked = false;

    // Start is called before the first frame update
    void Start()
    {
        //define at the start where the close rot is
        closeRotation = transform.rotation;
        //and also where the oopen rot is
        openRotation = Quaternion.Euler(transform.eulerAngles + openRotationOffset);
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpening)
        {
            // Debug.Log("opening door");
            // rotate accordingly
            transform.rotation = Quaternion.RotateTowards(transform.rotation, openRotation, openSpeed + Time.deltaTime);
        }
    }

    public void OpenDoor()
    {
        if (!lockedByPassword || isUnlocked)
        {
            isOpening = true;
            SoundManager.instance.PlayAudioClip(_openDoorSound);

        }
        else
        {
            Debug.Log("The door is locked. You need to enter a password.");
        }
    }

    public void CloseDoor()
    {
        isOpening = false;
        transform.rotation = closeRotation;
    }

    public void OpenLockedDoor()
    {
        if (lockedByPassword)
        {
            Debug.Log("Locked. Enter Password");
            return;
        }

        OpenDoor();
    }
}
