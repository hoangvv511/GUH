using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour {

    public string ButtonName;

    public void ChangeScenes(Button button)
    {
        ButtonName = button.GetComponentInChildren<Text>().text;
        int index = int.Parse(ButtonName);

        switch(index)
        {
            case 1:
                OpenScene("Level1");
                break;
            case 2:
                OpenScene("Level2");
                break;
            case 3:
                OpenScene("Leve3");
                break;
            case 4:
                OpenScene("Level4");
                break;
            case 5:
                OpenScene("Level5");
                break;
            case 6:
                OpenScene("Level6");
                break;
            case 7:
                OpenScene("Level7");
                break;
            case 8:
                OpenScene("Level8");
                break;
            case 9:
                OpenScene("Level9");
                break;
            case 10:
                OpenScene("Level10");
                break;

        }
    }

    public void OpenScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
	
	
}
