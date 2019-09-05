using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {
    public GameObject losego;
    public GameObject winGO;
    public PrisonEffectCode effect;
    public Text policeAlert;
    public Text scoreText;
    public void InitUI()
    {
        losego.SetActive(false);
        policeAlert.enabled = false;
        //effect.isPlayEffect = false;
        //effect.resetEffect();
        winGO.SetActive(false);
        
    }
    public void ShowPoliceAlert()
    {
        policeAlert.enabled = true;
    }
    public void disablePoliceAlert()
    {
        policeAlert.enabled = false;
    }
    public void SetScoreText(int score)
    {
        scoreText.text = "Score:"+score;
    }
    public void ResetScoreText()
    {
        scoreText.text = "Score:0";
    }
    public void ShowWinGame()
    {
        winGO.SetActive(true);
    }
    public void HideWinGame()
    {
        winGO.SetActive(false);
    }
    public void ShowLoseGame()
    {
        losego.SetActive(true);
        //effect.isPlayEffect = true;

    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void ReplayButtonDown()
    {
        GameControl.Instance.Restart();
    }
    public void RestartButtonDown()
    {
        GameControl.Instance.RestartWholeLevel();
    }
    public void HideLoseGame()
    {
        losego.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
