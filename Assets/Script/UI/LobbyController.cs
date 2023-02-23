using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyController : MonoBehaviour
{
    [SerializeField]
    private Button playButton, levelButton, quitButton, resetButton, lockStatusOkayButton, resetYesButton, resetNoButton;

    [SerializeField]
    private GameObject entryLayer, levelLayer, resetLayer, lockStatus;

    private int sceneToContinue, loadNextScene;

    private void Start()
    {
        SoundManager.Instance.StopMusic(Sounds.BackGround);
        SoundManager.Instance.PlayMusic(Sounds.BackGround);
        loadNextScene = SceneManager.GetActiveScene().buildIndex;
        entryLayer.SetActive(true);
        levelLayer.SetActive(false);
    }

    private void Awake()
    {
        playButton.onClick.AddListener(Play);
        levelButton.onClick.AddListener(SelectLevel);
        resetButton.onClick.AddListener(ResetLevels);
        quitButton.onClick.AddListener(Quit);
        lockStatusOkayButton.onClick.AddListener(TurnOffDisplayStatus);
        resetYesButton.onClick.AddListener(ResetYes);
        resetNoButton.onClick.AddListener(ResetNo);
    }

    private void Play()
    {
        SoundManager.Instance.PlayEffects(Sounds.ButtonClickPlay);
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
        SoundManager.Instance.PlayEffects(Sounds.ButtonClick);
        entryLayer.SetActive(false);
        levelLayer.SetActive(true);
    }

    private void ResetLevels()
    {
        SoundManager.Instance.PlayEffects(Sounds.ButtonClick);
        entryLayer.SetActive(false);
        resetLayer.SetActive(true);
    }

    private void ResetYes()
    {
        SoundManager.Instance.PlayEffects(Sounds.ButtonClickYes);
        LevelManager.Instance.SetLevelStatus("Level1", LevelStatus.Unlocked);
        LevelManager.Instance.SetLevelStatus("Level2", LevelStatus.Locked);
        LevelManager.Instance.SetLevelStatus("Level3", LevelStatus.Locked);
        LevelManager.Instance.SetLevelStatus("Level4", LevelStatus.Locked);
        LevelManager.Instance.SetLevelStatus("Level5", LevelStatus.Locked);
        PlayerPrefs.SetInt("SaveScene", 1);
        ResetNo();
    }

    private void ResetNo()
    {
        SoundManager.Instance.PlayEffects(Sounds.ButtonClickNo);
        resetLayer.SetActive(false);
        entryLayer.SetActive(true);
    }

    private void Quit()
    {
        SoundManager.Instance.PlayEffects(Sounds.ButtonClick);
        Application.Quit();
    }

    public void TurnOnDisplayStatus()
    {
        levelLayer.SetActive(false);
        lockStatus.SetActive(true);
    }

    private void TurnOffDisplayStatus()
    {
        SoundManager.Instance.PlayEffects(Sounds.ButtonCLickOkay);
        lockStatus.SetActive(false);
        levelLayer.SetActive(true);
    }
}
