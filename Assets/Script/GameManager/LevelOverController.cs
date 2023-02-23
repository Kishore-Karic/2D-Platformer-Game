using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    [SerializeField]
    private GameObject levelCompleteMessage;

    private int loadNextScene;

    private void Start()
    {
        loadNextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if(loadNextScene > 5)
        {
            loadNextScene = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerController>())
        {
            Debug.Log("Level Completed");
            levelCompleteMessage.SetActive(true);
            StartCoroutine("NextLevel");
        }
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(1.5f);
        levelCompleteMessage.SetActive(false);
        SceneManager.LoadScene(loadNextScene);
        LevelManager.Instance.MarkCurrentLevelComplete();
    }
}
