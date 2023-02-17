using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button playButton, levelButton, quitButton;
    [SerializeField]
    private GameObject entryLayer, levelLayer;

    private int sceneToContinue, loadNextScene;

    private void Start()
    {
        loadNextScene = SceneManager.GetActiveScene().buildIndex;
        entryLayer.SetActive(true);
        levelLayer.SetActive(false);
    }

    private void Awake()
    {
        playButton.onClick.AddListener(Play);
        levelButton.onClick.AddListener(SelectLevel);
        quitButton.onClick.AddListener(Quit);
    }

    private void Play()
    {
        sceneToContinue = PlayerPrefs.GetInt("SaveScene");

        if(sceneToContinue != 0)
        {
            SceneManager.LoadScene(sceneToContinue);
        } else
        {
            SceneManager.LoadScene(loadNextScene);
        }
    }

    private void SelectLevel()
    {
        entryLayer.SetActive(false);
        levelLayer.SetActive(true);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
