using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenBol : MonoBehaviour
{
    public GameObject settings,HowToPlay;
    public OpenBol open;

    public void Bolum_Open(string Name)
    {
        GameController.charahcterSpeedBool = true;
        SceneManager.LoadScene(Name);
    }
    public void SettingsOpen()
    {
        HowToPlay.SetActive(false);
        settings.SetActive(true);
    }
    public void HowToPlayOpen()
    {
        settings.SetActive(false);
        HowToPlay.SetActive(true);
    }
    public void CloseAlways()
    {
        settings.SetActive(false);
        HowToPlay.SetActive(false);
    }

}
