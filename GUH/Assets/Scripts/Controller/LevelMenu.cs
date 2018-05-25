using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour {

    public string ButtonName;
    public Vector3 ZoomIn;

    public void ChangeScenes(Button button)
    {
        ButtonName = button.name;
        int index = int.Parse(ButtonName);
        ZoomIn = button.transform.localScale;       
            switch (index)
            {
                case 1:
                ZoomButton(button);
                    OpenScene("Level1");
                    break;
                case 2:
                ZoomButton(button);
                OpenScene("Level2");
                    break;
                case 3:
                ZoomButton(button);
                OpenScene("Leve3");
                    break;
                case 4:
                ZoomButton(button);
                OpenScene("Level4");
                    break;
                case 5:
                ZoomButton(button);
                OpenScene("Level5");
                    break;
                case 6:
                ZoomButton(button);
                OpenScene("Level6");
                    break;
                case 7:
                ZoomButton(button);
                OpenScene("Level7");
                    break;
                case 8:
                ZoomButton(button);
                OpenScene("Level8");
                    break;
                case 9:
                ZoomButton(button);
                OpenScene("Level9");
                    break;
                case 10:
                ZoomButton(button);
                OpenScene("Level10");
                    break;
            }
    }

    public void ZoomButton(Button button)
    {
        ZoomIn.x = button.transform.localScale.x * 1.1f;
        ZoomIn.y = button.transform.localScale.y * 1.1f;
        button.transform.localScale = ZoomIn;
    }

    public void OpenScene(string SceneName)
    {   
        SceneManager.LoadScene(SceneName);
    }
	
	
}
