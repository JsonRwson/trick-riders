using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{   
    // Start is called before the first frame update
    public bool boosting;
    public float originalFOV;
    public float desiredFOV;
    public GameObject cube;

    [SerializeField]
    public Camera playerCam;
    public Camera mainCamera;
    public GameObject Player;
    public GameObject SafetyNet;

    void Start(){
        mainCamera = playerCam;
        originalFOV = mainCamera.fieldOfView;
        desiredFOV = 110f;
    }

    public void increaseSpeed(){
        if(GameObject.Find("Board").GetComponent<Controller>().currentFuel > 50 && boosting == false){
            SafetyNet.SetActive(true);
            cube.GetComponent<ConstantlyMove>().movespeed += cube.GetComponent<ConstantlyMove>().movespeed*1.5f;
            GameObject.Find("Board").GetComponent<Controller>().currentFuel -= 50;
            boosting = true;
            Invoke("resetSpeed", 6);
        }
    }

    void Update(){
        if(boosting == true)
        {
            if(mainCamera.fieldOfView < desiredFOV){
                mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, desiredFOV, 10*Time.deltaTime);
            }
        }

        if(boosting == false){
            if(mainCamera.fieldOfView > originalFOV){
                mainCamera.fieldOfView = Mathf.Lerp(mainCamera.fieldOfView, originalFOV, 10*Time.deltaTime);
            }
        }
    }

    public void resetSpeed(){
        SafetyNet.SetActive(false);
        cube.GetComponent<ConstantlyMove>().movespeed -= cube.GetComponent<ConstantlyMove>().movespeed*1.5f;
        boosting = false;
    }
}