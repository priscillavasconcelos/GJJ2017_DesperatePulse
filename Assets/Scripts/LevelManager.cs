using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public string creditsScene = "Credits";
    public string menuScene = "Menu";
    public string gameoverScene = "Gameover";
    public string gameScene = "Gameplay";
    public string victoryScene = "Victory";

    public void CallCreditsScene()
    {
        SceneManager.LoadScene(creditsScene);
    }

    public void CallMenuScene()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void CallGameScene()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void CallGameOverScene()
    {
        SceneManager.LoadScene(gameoverScene);
    }

    public void CallVictoryScene()
    {
        SceneManager.LoadScene(victoryScene);
    }
}
