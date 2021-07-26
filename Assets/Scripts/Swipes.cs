using System;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class Swipes : MonoBehaviour {

  public float swipeThreshold = 200f;
  public float timeThreshold = 0.01f;

  private Vector2 fingerDown;
  private DateTime fingerDownTime;
  private Vector2 fingerUp;
  private DateTime fingerUpTime;
  public float distance = 0.2f;
  public GameObject board;
  public bool isTricking;
  public GameObject Player2;
  public int trickRank;
  public int trickRankClone;

  void FixedUpdate () {
  }

  void Start(){
    isTricking = false;
    trickRank = 0;
    trickRankClone = 0;
  }

  private void Update () {

    if (Input.GetMouseButtonDown(0)) {
      this.fingerDown = Input.mousePosition;
      this.fingerUp = Input.mousePosition;
      this.fingerDownTime = DateTime.Now;
    }
    if (Input.GetMouseButtonUp(0)) {
      this.fingerDown = Input.mousePosition;
      this.fingerUpTime = DateTime.Now;
      this.CheckSwipe();
    }
    foreach (Touch touch in Input.touches) {
      if (touch.phase == TouchPhase.Began) {
        this.fingerDown = touch.position;
        this.fingerUp = touch.position;
        this.fingerDownTime = DateTime.Now;
      }
      if (touch.phase == TouchPhase.Ended) {
        this.fingerDown = touch.position;
        this.fingerUpTime = DateTime.Now;
        this.CheckSwipe();
      }
    }
  }

  private void CheckSwipe() {
    float duration = (float)this.fingerUpTime.Subtract(this.fingerDownTime).TotalSeconds;
    if (duration > this.timeThreshold) return;

    float deltaX = this.fingerDown.x - this.fingerUp.x;
    if (Mathf.Abs(deltaX) > this.swipeThreshold) {
      if (deltaX > 0) {
        this.OnSwipeRight();
        //Debug.Log("right");
      } else if (deltaX < 0) {
        this.OnSwipeLeft();
        //Debug.Log("left");
      }
    }

    float deltaY = fingerDown.y - fingerUp.y;
    if (Mathf.Abs(deltaY) > this.swipeThreshold) {
      if (deltaY > 0) {
        this.OnSwipeUp();
        //Debug.Log("up");
      } else if (deltaY < 0) {
        this.OnSwipeDown();
        //Debug.Log("down");
      }
    }

    this.fingerUp = this.fingerDown;
  }


    float verticalMove()
    {
        return Mathf.Abs(fingerDown.y - fingerUp.y);
    }

    float horizontalValMove()
    {
        return Mathf.Abs(fingerDown.x - fingerUp.x);
    }

    //////////////////////////////////CALLBACK FUNCTIONS/////////////////////////////
    void OnSwipeUp()
    {
      Debug.Log("Swipe up");
      trickRankClone += 1;
      if(board.GetComponent<BoardCollide>().Grounded == false)
      {
        if(isTricking == false)
        {
          Player2.GetComponent<Animator>().ResetTrigger("NotTricking");
          Player2.GetComponent<Animator>().SetTrigger("Tricking");
          isTricking = true;
          transform.DORotate(new Vector3(360, 0, 0), 1f, RotateMode.FastBeyond360);
          isTricking = false;
        }
       
      }
    }

    void OnSwipeDown()
    {
      Debug.Log("Swipe Down");
      trickRankClone += 1;
      if(board.GetComponent<BoardCollide>().Grounded == false)
      {
        if(isTricking == false)
        {
          Player2.GetComponent<Animator>().ResetTrigger("NotTricking");
          Player2.GetComponent<Animator>().SetTrigger("Tricking");
          isTricking = true;
          transform.DORotate(new Vector3(-360, 0, 0), 1f, RotateMode.FastBeyond360);
          isTricking = false;
        }
        
      }
    }

    void OnSwipeLeft()
    {
      Debug.Log("Swipe Left");
      trickRankClone += 1;
      if(board.GetComponent<BoardCollide>().Grounded == false)
      {
        if(isTricking == false)
        {
          Player2.GetComponent<Animator>().ResetTrigger("NotTricking");
          Player2.GetComponent<Animator>().SetTrigger("Tricking");
          isTricking = true;
          transform.DORotate(new Vector3(0, -360, 0), 1f, RotateMode.FastBeyond360);
          isTricking = false;;
        }
      }
    }

    void OnSwipeRight()
    {
      Debug.Log("Swipe Right");
      trickRankClone += 1;
      if(board.GetComponent<BoardCollide>().Grounded == false)
      {
        if(isTricking == false)
        {
          Player2.GetComponent<Animator>().ResetTrigger("NotTricking");
          Player2.GetComponent<Animator>().SetTrigger("Tricking");
          isTricking = true;
          transform.DORotate(new Vector3(0, 360, 0), 1f, RotateMode.FastBeyond360);
          isTricking = false;
        }
      }
    }
}