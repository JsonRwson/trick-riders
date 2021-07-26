using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JumpCharge : MonoBehaviour
{
    public int jumpStage;
    public GameObject player;
    public int counter;
    public GameObject board;
    public float distance = 0.2f;
    public int height;
    public GameObject trail1;
    public Color stage3rgb = new Color (102, 0, 255);
    public Color originalColor;
    public GameObject cube;
    public GameObject Player2;
    public bool dividedOnce;
    public bool dividedTwice;
    
    // Start is called before the first frame update
    void Start()
    {
        dividedTwice = false;
        dividedOnce = false;
        jumpStage = 0;
        trail1.GetComponent<TrailRenderer>().material.color = new Color (0, 0, 255);
        originalColor = trail1.GetComponent<TrailRenderer>().material.color;
    }

    public void down()
    {
        jumpStage = 1;
    }

    public void resetSpeed()
    {
        if(board.GetComponent<BoardCollide>().Grounded == true){
            trail1.GetComponent<TrailRenderer>().material.color = originalColor;
            if(jumpStage == 1){
                jumpStage = 0;
            }
            if(jumpStage == 2){
                cube.GetComponent<ConstantlyMove>().movespeed += (cube.GetComponent<ConstantlyMove>().movespeed*2);
                jumpStage = 0;
            }

            if(jumpStage == 3){
                cube.GetComponent<ConstantlyMove>().movespeed += (cube.GetComponent<ConstantlyMove>().movespeed*3);
                jumpStage = 0;
            }
        }
        jumpStage = 0;
        trail1.GetComponent<TrailRenderer>().material.color = originalColor;
    }

    public void up(){
        Player2.GetComponent<Animator>().ResetTrigger("ToCrouch");
        Player2.GetComponent<Animator>().SetTrigger("UnCrouch");
        trail1.GetComponent<TrailRenderer>().material.color = originalColor;
        Debug.Log("UP");
        if(jumpStage == 1)
        {
            height = 20;
        }
        if(jumpStage == 2)
        {
            height = 50;
        }
        if(jumpStage == 3)
        {
            height = 65;
        }
        jumpStage = 0;
        if (board.GetComponent<BoardCollide>().Grounded == true)
        {
            player.GetComponent<Rigidbody>().AddForce(new Vector3(0, height+cube.GetComponent<ConstantlyMove>().movespeed/2, 0), ForceMode.Impulse);
            height = 15;
        }
        resetSpeed();
        board.GetComponent<BoardCollide>().Grounded = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(board.GetComponent<BoardCollide>().Grounded == true){

            if (jumpStage == 1)
            {
                Debug.Log("Stage 1");
                counter += 1;
            }
            if(counter == 20 || jumpStage == 2)
            {
                Player2.GetComponent<Animator>().SetTrigger("ToCrouch");
                Debug.Log("Stage 2");
                jumpStage = 2;
                counter += 1;
                trail1.GetComponent<TrailRenderer>().material.color = stage3rgb;
                if(dividedOnce == false)
                {
                    cube.GetComponent<ConstantlyMove>().movespeed -= (cube.GetComponent<ConstantlyMove>().movespeed/2);
                    dividedOnce = true;
                }            }
            if(counter == 60 || jumpStage == 3)
            {
                Player2.GetComponent<Animator>().SetTrigger("ToCrouch");
                Debug.Log("Stage 3");
                jumpStage = 3;
                trail1.GetComponent<TrailRenderer>().material.color = stage3rgb;
                if(dividedTwice == false)
                {
                    cube.GetComponent<ConstantlyMove>().movespeed -= (cube.GetComponent<ConstantlyMove>().movespeed/3);
                    dividedTwice = true;
                }
                counter = 0;
            }
        }
    }
}
