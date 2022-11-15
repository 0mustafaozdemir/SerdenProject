using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static Animator anim;
    public GameObject deadPanel;
    public static PlayerController Instance;
    private void Start()
    {
        LevelMenu.levelCount = PlayerPrefs.GetInt("myNumber");
        anim = GetComponent<Animator>();
        anim.SetBool("GameStart", true);
    }
    private void Awake()
    {
        
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

    }

    public void SaveSettings()
    {
        PlayerPrefs.SetInt("myNumber", LevelMenu.levelCount);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            GameController.charahcterSpeedBool = false;
            deadPanel.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Bitti");
        }
        if (collision.gameObject.tag == "TileCollider")
        {
           
            GameController.charahcterSpeedBool = false;
            deadPanel.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Bitti");
        }
        if (collision.gameObject.tag == "Level1")
        {
            SaveSettings();
            Bolum_Open("Level - 2");
            LevelMenu.levelCount = 1;
        }
        if (collision.gameObject.tag == "Level2")
        {
            SaveSettings();
            Bolum_Open("Level - 3");
            LevelMenu.levelCount = 2;
        }
        if (collision.gameObject.tag == "Level3")
        {
            SaveSettings();
            Bolum_Open("Level - 4");
            LevelMenu.levelCount = 3;
        }
        if (collision.gameObject.tag == "Level4")
        {
            SaveSettings();
            Bolum_Open("Level - 5");
            LevelMenu.levelCount = 4;
        }
        if (collision.gameObject.tag == "Level5")
        {
            Bolum_Open("Level - 6");
            LevelMenu.levelCount = 5;
        }
        if (collision.gameObject.tag == "Level6")
        {
            Bolum_Open("Level - 7");
            LevelMenu.levelCount = 6;
        }
        if (collision.gameObject.tag == "Level7")
        {
            Bolum_Open("Level - 8");
            LevelMenu.levelCount = 7;

        }
        if (collision.gameObject.tag == "Level8")
        {
            Bolum_Open("Level - 9");
            LevelMenu.levelCount = 8;
        }
        if (collision.gameObject.tag == "Level9")
        {
            Bolum_Open("Level - 10");
            LevelMenu.levelCount = 9;
        }
        if (collision.gameObject.tag == "Level10")
        {
            Bolum_Open("Level - 11");
            LevelMenu.levelCount = 10;
        }
        if (collision.gameObject.tag == "Level11")
        {
            Bolum_Open("Level - 12");
            LevelMenu.levelCount = 11;
        }
        if (collision.gameObject.tag == "Level12")
        {
            Bolum_Open("Level - 13");
            LevelMenu.levelCount = 12;
        }
        if (collision.gameObject.tag == "Level13")
        {
            Bolum_Open("Level - 14");
            LevelMenu.levelCount = 13;
        }
        if (collision.gameObject.tag == "Level14")
        {
            Bolum_Open("Level - 15");
            LevelMenu.levelCount = 14;
        }
        if (collision.gameObject.tag == "Level15")
        {
            Bolum_Open("Level - 16");
            LevelMenu.levelCount = 15;
        }
        if (collision.gameObject.tag == "Level16")
        {
            Bolum_Open("Level - 17");
            LevelMenu.levelCount = 16;
        }
        if (collision.gameObject.tag == "Level17")
        {
            Bolum_Open("Level - 18");
            LevelMenu.levelCount = 17;
        }
        if (collision.gameObject.tag == "Level18")
        {
            Bolum_Open("Level - 19");
            LevelMenu.levelCount = 18;
        }
        if (collision.gameObject.tag == "Level19")
        {
            Bolum_Open("Level - 20");
            LevelMenu.levelCount = 19;
        }
        if (collision.gameObject.tag == "Level20")
        {
            LevelMenu.levelCount = 20;
            Bolum_Open("Menu");
        }

        if (collision.gameObject.tag == "Enemy")
        {
            GameController.charahcterSpeedBool = false;
            deadPanel.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Bitti");
        }
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            GameController.charahcterSpeedBool = false;
            deadPanel.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Bitti");
        }
    }
    public void dead()
    {
        GameController.charahcterSpeedBool = false;
        deadPanel.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Bitti");
    }
    public void Bolum_Open(string Name)
    {
        GameController.charahcterSpeedBool = true;
        SceneManager.LoadScene(Name);
    }

}
