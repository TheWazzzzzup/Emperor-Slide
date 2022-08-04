using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseDeathMenu : MonoBehaviour
{
    public GameObject PauseUi;
    public static bool GamePaused = false;
    public static bool IsPlayerDead = false;

    public UnityEvent gamePause;
    public UnityEvent playerDeathMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("pressing ESC");
        }
        if (Input.GetKeyDown(KeyCode.Escape) && IsPlayerDead == false)
        {
            if (GamePaused)
            {
                Resume();
            }
            else
            {
                // Pause();
                gamePause.Invoke();
            }
        }
    }
    public static bool CanPlayerMove()
    {
        if (GamePaused == true)
        {
            return false;
        }
        else if (IsPlayerDead == true)
        {
            return false;
        }
        else return true;
    }
    public static void Restart()
    {
        IsPlayerDead = false;
        GamePaused = false;
        SceneManager.LoadScene(1);
        IsPlayerDead = false;
        SpawnTriggerAndJump.hp = 100f;
        Debug.Log($"restart called {SpawnTriggerAndJump.hp} and playerdead = {IsPlayerDead}");
    }
    public void Resume()
    {
        PauseUi.SetActive(false);
        GamePaused = false;
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit mid game");
    }
    public void QuitDeath()
    {
        Application.Quit();
        Debug.Log("Sore Loser");
    }
    void Pause()
    {
        PauseUi.SetActive(true);
        GamePaused = true;
    }
}
