using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isStarted = false;
    private bool isNotStarted = false;
    private bool isSettingActive = false;
    private bool isSoundActive = false;
    private bool isVibrateActive = false;
    public GameObject settings;
    public GameObject settingsPanel;
    public GameObject soundOnButton;
    public GameObject soundOffButton;
    public GameObject vibrateOnButton;
    public GameObject VibratedOffButton;
    public GameObject restart;
    public GameObject button;
    public GameObject levelProgress;
    public GameObject levelProgressStart;
    public GameObject swipeBar;
    public GameObject swipeHand;

    private void Update()
    {
        if (!isNotStarted && Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            isNotStarted = true;
        }
        LevelProgress();
        Swipe();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
        GameManager.isStarted = false;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("ikinci level");
    }

    public void Settings()
    {
        settingsPanel.SetActive(!isSettingActive); 
        isSettingActive = !isSettingActive;
    }


    public void SoundButton()
    {
        soundOffButton.SetActive(!isSoundActive);
        isSoundActive = !isSoundActive;
    }

    public void Vibrate()
    {
        VibratedOffButton.SetActive(!isVibrateActive);
        isVibrateActive = !isVibrateActive;
    }

    public void LevelProgress()
    {
        if (GameManager.isStarted == true)
        {
            levelProgressStart.SetActive(false);
            levelProgress.SetActive(true);
        }
    }
    
    public void Swipe()
    {
        if (GameManager.isStarted && swipeBar.activeInHierarchy && swipeHand.activeInHierarchy)
        {
            swipeHand.SetActive(false);
            swipeBar.SetActive(false);
        }
    }
}
