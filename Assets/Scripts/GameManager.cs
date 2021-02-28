using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool isStarted = false;
    public bool isNotStarted = false;
    private bool isSettingActive = false;
    public GameObject settings;
    public GameObject soundOnButton;
    public GameObject soundOffButton;

    private void Update()
    {
        if (!GameManager.isStarted && Input.GetMouseButtonDown(0))
        {
            isStarted = true;
            isNotStarted = true;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("ikinci level");
    }

    public void Settings()
    {
        settings.SetActive(!isSettingActive);
        isSettingActive = !isSettingActive;
    }

    public void SoundButton()
    {
        if (soundOnButton)
        {
            soundOffButton.SetActive(true);
            soundOnButton.SetActive(false);
        }
        else
        {
            soundOffButton.SetActive(false);
            soundOnButton.SetActive(true);
        }
    }
}
