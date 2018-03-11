using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OfflineGameController : MonoBehaviour {

    [SerializeField] private GameObject endGameWindow;
    [SerializeField] private GameObject pauseGameWindow;

    private bool gameOver;
    private bool isPaused;
    private int playerHealth1;
    private int playerHealth2;

	// Use this for initialization
	void Start () {

        gameOver = false;
        isPaused = false;

        Debug.Assert(pauseGameWindow != null);
        Debug.Assert(endGameWindow != null);
        endGameWindow.SetActive(false);
        pauseGameWindow.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (!gameOver)
        {
            playerHealth1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<PlayerData>().currentHealth;
            playerHealth2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<PlayerData>().currentHealth;

            if (playerHealth1 <= 0 || playerHealth2 <= 0)
            {
                endGameWindow.SetActive(true);
                gameOver = true;
            }
        }
	}

    public bool getGameOver
    {
        get { return gameOver; }
    }

    public bool getIsPaused
    {
        get { return isPaused; }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(GameConstants.LEVELS.MenuScene.ToString());
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseGameWindow.SetActive(true);
    }

    public void UnPauseGame()
    {
        isPaused = false;
        pauseGameWindow.SetActive(false);
    }
}
