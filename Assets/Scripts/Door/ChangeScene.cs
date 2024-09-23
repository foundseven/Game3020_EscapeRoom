using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] 
    private string sceneName;
    public void ChangeToNewScene()
    {
       LevelManager.Instance.LoadScene(sceneName);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Entered new scene area");
            ChangeToNewScene();
        }
    }
}
