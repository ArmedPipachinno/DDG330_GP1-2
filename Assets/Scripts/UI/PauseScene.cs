using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScene : MonoBehaviour
{
    [field: SerializeField] GameObject PauseMenuUI;
    [field: SerializeField] string MenuScenename;
    private bool IsPaused = false;

    //public static PauseScene _Instance;

    private void Awake()
    {
        //if (_Instance == null)
        //{
        //    _Instance = this;
        //}
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        IsPaused = true;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        IsPaused = false;
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene(MenuScenename);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
