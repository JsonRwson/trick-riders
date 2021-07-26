using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Controller : MonoBehaviour
{
    [SerializeField]
    public float fuel = 100;
    public float currentFuel;
    public Slider fuelSlider;
    public float fuelRate = 0.01f;
    public Text DistanceVal;
    public Text finalDistance;
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public int score;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        currentFuel = 0;
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
        score = Convert.ToInt32((transform.position.z)+14);
    }

    // Update is called once per frame
    void Update()
    {
        score = Convert.ToInt32((transform.position.z)+14+Player.GetComponent<Swipes>().trickRank*100);
        fuelSlider.value = currentFuel / fuel;
        currentFuel += fuelRate * Time.deltaTime/6;
        if(currentFuel > 100){
            currentFuel = 100;
        }
        DistanceVal.text = score.ToString();
        finalDistance.text = score.ToString();
    }
}
