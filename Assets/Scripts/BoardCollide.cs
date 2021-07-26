using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoardCollide : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject GameOver;
    public GameObject HUD;
    public GameObject leftButton;
    public GameObject rightButton;
    public GameObject boostObject;
    public bool Grounded;
    public GameObject Player2;
    public GameObject Player;

    void Start()
    {
    }   

    // Update is called once per frame
    void Update()
    {
        if(Player2.transform.position.y < -20){
            GameOver.SetActive(true);
            HUD.SetActive(false);
            leftButton.SetActive(false);
            rightButton.SetActive(false);
            gameIsOver();
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Obstacle"){
            if(boostObject.GetComponent<Boost>().boosting != true)
            {
                GameOver.SetActive(true);
                HUD.SetActive(false);
                leftButton.SetActive(false);
                rightButton.SetActive(false);
                gameIsOver();
            }
        }
        if (other.tag == "Plane")
        {
            Player2.GetComponent<Animator>().ResetTrigger("Tricking");
            Player2.GetComponent<Animator>().SetTrigger("NotTricking");
            Grounded = true;
            GetComponent<Controller>().currentFuel += (float)Player.GetComponent<Swipes>().trickRankClone/3;
            Player.GetComponent<Swipes>().trickRank = Player.GetComponent<Swipes>().trickRankClone;
        }
    }

    void OnTriggerExit(Collider other)
    { 
        if (other.tag == "Plane")
        {
            Grounded = false;
        }
    }

    void OnTriggerStay(Collider other) {
        if (other.tag == "Plane")
        {
            Grounded = true;
        }
    }
    void gameIsOver(){
        Time.timeScale = 0;
    }
}