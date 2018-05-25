using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteController : MonoBehaviour {

    public Animator anim;
    //public static bool isComplete = false;

    //public void PlayerIsComplete(bool complete)
    //{
    //    isComplete = complete;
    //}

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void ShowTheMenu()
    {
         Time.timeScale = 0;
         anim.SetBool("isComplete", true);
    }

    public void RestartLevel()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("LevelMenu");
    }
}
