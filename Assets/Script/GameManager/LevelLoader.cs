using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private LobbyController lobbyController;

    private Button levelButton;

    public string LevelName;

    private void Awake()
    {
        levelButton = GetComponent<Button>();
        levelButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(LevelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                SoundManager.Instance.PlayEffects(Sounds.ButtonClick);
                lobbyController.TurnOnDisplayStatus();
                break;

            case LevelStatus.Unlocked:
                SoundManager.Instance.PlayEffects(Sounds.ButtonClickPlay);
                SceneManager.LoadScene(LevelName);
                break;

            case LevelStatus.Completed:
                SoundManager.Instance.PlayEffects(Sounds.ButtonClickPlay);
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
}
