using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    [SerializeField]
    private Button restartButton, mainmenuButton;

    private void Awake()
    {
        restartButton.onClick.AddListener(Reload);
        mainmenuButton.onClick.AddListener(MainMenu);
    }

    public void PlayerDead()
    {
        gameObject.SetActive(true);
    }

    private void Reload()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }

    private void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
