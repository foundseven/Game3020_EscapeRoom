using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] 
    private string sceneName;

    [SerializeField]
    private string requiredLevel;
    
    public void ChangeToNewScene()
    {
       LevelManager.Instance.LoadScene(sceneName);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Entered new scene area");

            if(sceneName == "Level1" || LevelManager.Instance.IsLevelComplete(requiredLevel))
            {
                ChangeToNewScene();
            }
            else
            {
                Debug.Log("You must complete the previous level first!");
                Debug.Log("Need: " + requiredLevel);
            }
        }
    }
}
