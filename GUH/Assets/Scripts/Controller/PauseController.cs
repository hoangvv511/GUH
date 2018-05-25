using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour {

    public Animator anim;
    public static bool pause = false;


    public void Pause(bool isPause)
    {
        pause = isPause;
    }

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void ShowTheMenu()
    {
        Time.timeScale = 0;
        anim.SetBool("SlideTheMenu", true);
    }

    public void HideTheMenu()
    {
        Time.timeScale = 1;
        anim.SetBool("SlideTheMenu", false);
    }

    void Update()
    {

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);      
    }

    public void MenuLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelMenu");
    }
}
