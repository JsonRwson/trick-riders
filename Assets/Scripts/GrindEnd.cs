using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class GrindEnd : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cube;
    public GameObject Player;

    void Start(){
        cube = GameObject.Find("Player(MovementController)");
        Player = GameObject.Find("PlayerController");
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Board"){
            cube.GetComponent<ConstantlyMove>().grinding = false;
            Player.transform.DORotate(new Vector3(0, 0, 0), 0.2f, RotateMode.FastBeyond360);
        }
    }
}
