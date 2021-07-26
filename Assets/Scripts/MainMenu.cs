using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu: MonoBehaviour
{
    private const float CAMERA_TRANSITION_SPEED = 3.0f;

    private Transform cameraTransform;
    private Transform cameraDesiredLookAt;

    private void Start()
    {   
        cameraTransform = Camera.main.transform;
    }
    private void Update()
    {
        if(cameraDesiredLookAt != null) 
        {
            cameraTransform.rotation = Quaternion.Slerp(cameraTransform.rotation, cameraDesiredLookAt.rotation, CAMERA_TRANSITION_SPEED * Time.deltaTime);
        }
    }
    private void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LookAtMenu(Transform menuTransform)
    {
        cameraDesiredLookAt = menuTransform;
    }
}
