using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {
    public void gameScene()
    {
        SceneManager.LoadScene("gameScene");
    }
    public void shopScene()
    {
        SceneManager.LoadScene("shopScene");
    }
    public void settingScene()
    {
        SceneManager.LoadScene("settingScene");
    }
    public void tutorialScene()
    {
        SceneManager.LoadScene("tutorialScene");
    }
    public void selectScene()
    {
        SceneManager.LoadScene("selectScene");
    }
    public void startScene()
    {
        SceneManager.LoadScene("startScene");
    }
}
