using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.EventSystems;

public class GameController : MonoBehaviour
{
    public Button PlayButton;
    public GameObject BlockButton, TrapButton, JumpButton, DestroyButton;
    public GameObject camera;
    public Vector2 finishTransform;
    float charachterSpeed;
    public Animator runCharachter, jumpCharahcter;
    private Vector3 mousePosition;
    private Vector2 direction;
    private Vector2 mousePos;
    public static bool charahcterSpeedBool = true;
    public GameObject blockPrefab, jumpBlockPrefab, wireBlockPrefab, Kare;
    public bool finalBlockBool;
    public GameObject helpGameObject;
    public GameObject finalObject;
    public GameObject PausePanel;
    public Rigidbody2D RB;
    public GameObject mainCharachter;
    public static bool mainCharachterSpeed;
    private object moveForward;
    public GameController game;
    bool isClick, ButtonClick;

    public bool blockIsTragger;

    private void Start()
    {
        Time.timeScale = 1;
        charahcterSpeedBool = false;
        mainCharachterSpeed = true;
    }
    void Update()
    {
        if (blockIsTragger == true)
        {
            charachterSpeed = 0.5f;
        }
        else
            charachterSpeed = 2f;

        if (charahcterSpeedBool == true)
        {
            mainCharachter.transform.position += new Vector3(charachterSpeed, 0, 0) * Time.deltaTime * 1;
        }
        ColorButtonBlock();
        ColorButton();
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y));
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero, Mathf.Infinity);
        if (blockIsTragger == false)
        {
            if (isClick == false)
            {
                if (hit.collider != null)
                {
                    if (Input.GetMouseButton(0))
                    {
                        if (hit.collider.gameObject.name == "Square")
                        {
                            if (hit.collider.tag != "Jump" && hit.collider.tag != "Trap" && hit.collider.tag != "Block")
                            {

                                if (hit.collider.gameObject.name == "Square")
                                {
                                    Kare = hit.collider.gameObject;
                                    Kare.gameObject.GetComponent<SpriteRenderer>().enabled = hit.collider.GetComponent<SpriteRenderer>().enabled = true;

                                }

                                if (finalObject == blockPrefab)
                                {
                                    Kare.gameObject.GetComponent<SpriteRenderer>().enabled = hit.collider.GetComponent<SpriteRenderer>().enabled = false;
                                    var go = Instantiate(finalObject, transform.position, Quaternion.identity);
                                    go.transform.position = hit.collider.gameObject.transform.position;
                                }
                                if (finalObject == jumpBlockPrefab)
                                {
                                    Kare.gameObject.GetComponent<SpriteRenderer>().enabled = hit.collider.GetComponent<SpriteRenderer>().enabled = false;
                                    var go2 = Instantiate(finalObject, transform.position, Quaternion.identity);
                                    go2.transform.position = hit.collider.gameObject.transform.position;
                                }
                                if (finalObject == wireBlockPrefab)
                                {
                                    Kare.gameObject.GetComponent<SpriteRenderer>().enabled = hit.collider.GetComponent<SpriteRenderer>().enabled = false;
                                    var go3 = Instantiate(finalObject, transform.position, Quaternion.identity);
                                    go3.transform.position = hit.collider.gameObject.transform.position;
                                }
                            }
                        }
                    }
                }
            }
        }
        if (blockIsTragger == true)
        {
            if (hit.collider != null)
            {
                Kare.gameObject.GetComponent<SpriteRenderer>().enabled = hit.collider.GetComponent<SpriteRenderer>().enabled = true;
                if (hit.collider.tag == "Block")
                {
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.tag == "Jump")
                {
                    Destroy(hit.collider.gameObject);
                }
                else if (hit.collider.tag == "Trap")
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }

    }
    public void buttonDestroy()
    {
        blockIsTragger = true;
        finalObject = null;
        charachterSpeed = 0.5f;
    }
    public void ColorButtonBlock()
    {
        if (finalObject != null)
        {
            if (finalObject.tag == "Block")
            {
                BlockButton.GetComponent<Image>().color = Color.black;
            }
            else { BlockButton.GetComponent<Image>().color = Color.white; }
        }
        if (blockIsTragger == true)
        {
            TrapButton.GetComponent<Image>().color = Color.white;
            JumpButton.GetComponent<Image>().color = Color.white;
            BlockButton.GetComponent<Image>().color = Color.white;
            DestroyButton.GetComponent<Image>().color = Color.black;
        }
        else
            DestroyButton.GetComponent<Image>().color = Color.white;

    }
    public void ColorButton()
    {
        if (finalObject != null)
        {
            if (finalObject.name == "JumpBlock")
            {
                JumpButton.GetComponent<Image>().color = Color.black;
            }
            else
                JumpButton.GetComponent<Image>().color = Color.white;
            if (finalObject.name == "WİrePrefab")
            {
                TrapButton.GetComponent<Image>().color = Color.black;
            }
            else
                TrapButton.GetComponent<Image>().color = Color.white;

        }

        BlockButton = GameObject.FindGameObjectWithTag("Image");
        JumpButton = GameObject.FindGameObjectWithTag("Image1");
        TrapButton = GameObject.FindGameObjectWithTag("Image2");

    }

    public void SagaGit()
    {
        PlayerController.anim.SetBool("Move", true);
        ButtonClick = true;
        charahcterSpeedBool = true;
        charachterSpeed = 2;
    }
    public void BlockButtonInstantiate()
    {
        blockIsTragger = false;
        finalObject = null;
        finalObject = blockPrefab;
    }
    public void JumpBlockButtonInstantiate()
    {
        blockIsTragger = false;
        finalObject = null;
        finalObject = jumpBlockPrefab;
    }
    public void WireBlockButtonInstantiate()
    {
        blockIsTragger = false;
        finalObject = null;
        finalObject = wireBlockPrefab;
    }
    public void Bolum_Open(string Name)
    {
        ButtonClick = false;
        SceneManager.LoadScene(Name);
        Rigidbody2D rb = mainCharachter.GetComponent<Rigidbody2D>();
    }
    public void ReadyGame()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        charahcterSpeedBool = true;
    }
    public void OpenPausePanel()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        charahcterSpeedBool = false;
    }
    public void HelpPanelOpen()
    {
        mainCharachterSpeed = false;
        helpGameObject.SetActive(true);
    }
    public void HelpPanelClose()
    {
        mainCharachterSpeed = true;
        helpGameObject.SetActive(false);
    }


}
