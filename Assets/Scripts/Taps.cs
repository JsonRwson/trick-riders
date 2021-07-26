using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taps : MonoBehaviour
{
    private int leftSwipes;
    private int rightSwipes;
    private float desiredX;
    public int lane;
    public GameObject player;
    public GameObject Cube;
    // public GameObject playerMimic;
    // Start is called before the first frame update
    void Start()
    {
        leftSwipes = 1;
        rightSwipes = 1;
        lane = 0;  
    }

    // Update is called once per frame
    void Update()
    {
        if(!Cube.GetComponent<ConstantlyMove>().grinding){
            player.transform.position = Vector3.Lerp(player.transform.position, new Vector3(desiredX, player.transform.position.y, player.transform.position.z), 10*Time.deltaTime);
            // playerMimic.transform.position = Vector3.Lerp(playerMimic.transform.position, new Vector3(desiredX, playerMimic.transform.position.y, playerMimic.transform.position.z), 10*Time.deltaTime);

            if(lane == 1){
                desiredX = 6.5f;
            }

            if(lane == 0){
                desiredX = 0f;
            }

            if(lane == -1){
                desiredX = -6.5f;
            }
        }
    }

    public void onTouchLeft()
    {
        Debug.Log("Left Tap");
        if (leftSwipes == 1 || leftSwipes == 2){
            leftSwipes--;
            rightSwipes++;
            lane-= 1;
      }
    }

    public void onTouchRight()
    {
        Debug.Log("Right Tap");
        if (rightSwipes == 1 || rightSwipes == 2){
            rightSwipes--;
            leftSwipes++;
            lane+=1;
      }
    }
}
