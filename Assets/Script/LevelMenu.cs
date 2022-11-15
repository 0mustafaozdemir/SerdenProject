using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public List<Button> levelButton = new List<Button>();
    public static int levelCount = 0;
 
    
    void Update()
    {
        levelControl();
    }
    public void levelControl()
    {
        for (int i = 0; i < levelCount; i++)
        {
            levelButton[i].interactable = true;
        }
    }

    public void Bolum_Open(string Name)
    {
        Application.LoadLevel(Name);
    }
}
