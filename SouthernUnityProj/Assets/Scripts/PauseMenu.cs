using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool IsGamePaused = false;
    public GameObject PauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
        IsGamePaused = false;
    }
    void Pause()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
        IsGamePaused = true;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ReturnToMain()
    {
        SceneManager.LoadScene("UI_Title");
    }
    public void PauseButton()
    {
        if (IsGamePaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
}
