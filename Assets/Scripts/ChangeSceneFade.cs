using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneFade : MonoBehaviour
{
    public Animator animator;
    private string sceneName;

    void Start(){
        Time.timeScale = 1;
        sceneName = "Track";
    }
    public void btn_change_scene(string scene_name)
    {
        sceneName = scene_name;
        animator.SetTrigger("FadeOut");
    }

    public void onFadeComplete()
    {
        SceneManager.LoadScene(sceneName);
    }
}
