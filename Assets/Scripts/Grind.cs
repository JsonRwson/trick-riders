using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Grind : MonoBehaviour
{
    public Transform end;
    public GameObject Cube;
    public GameObject Player;
    public GameObject Board;

    void Start(){
        Cube = GameObject.Find("Player(MovementController)");
        Player = GameObject.Find("PlayerController");
        Board = GameObject.Find("Board");
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Board"){
            Board.GetComponent<BoardCollide>().Grounded = true;
            Player.transform.DORotate(new Vector3(0, 60, 0), 0.2f, RotateMode.FastBeyond360);
            Cube.GetComponent<ConstantlyMove>().grinding = true;
            iTween.MoveTo(Player, iTween.Hash("position", end.transform.position, "time", 0.5f, "easetype", iTween.EaseType.linear));
        }
    }
}
