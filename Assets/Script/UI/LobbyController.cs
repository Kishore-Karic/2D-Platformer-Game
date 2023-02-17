using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button playButton, quitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(Play);
        quitButton.onClick.AddListener(Quit);
    }

    private void Play()
    {
        SceneManager.LoadScene(1);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
