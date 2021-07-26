using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject HUD;
    public GameObject leftButton;
    public GameObject rightButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
        HUD.SetActive(false);
        leftButton.SetActive(false);
        rightButton.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        HUD.SetActive(true);
        leftButton.SetActive(true);
        rightButton.SetActive(true);
    }
}
