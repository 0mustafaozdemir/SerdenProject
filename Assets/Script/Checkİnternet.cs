using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Checkİnternet : MonoBehaviour
{
    [SerializeField] Text loadingText;
    [SerializeField] Text openText;
    [SerializeField] Text connectionErrorText;
    [SerializeField] Button tryAgainButton;
    [SerializeField] Button playButton;

    private void Start()
    {
        StartCoroutine(CheckInternetConnection());
    }


    IEnumerator CheckInternetConnection()
    {
        UnityWebRequest request = new UnityWebRequest("http://google.com");
        yield return request.SendWebRequest();
        if (request.error != null)
        {
            loadingText.gameObject.SetActive(false);
            connectionErrorText.gameObject.SetActive(true);
            tryAgainButton.gameObject.SetActive(true);
        }
        else
        {
            openText.gameObject.SetActive(true);
            loadingText.gameObject.SetActive(false);
            playButton.gameObject.SetActive(true);
        }

    }

    public void TryAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Play(string name)
    {
        SceneManager.LoadScene(name);
    }
}
