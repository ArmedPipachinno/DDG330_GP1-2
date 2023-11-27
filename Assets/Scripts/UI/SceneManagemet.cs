using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [field: SerializeField] string StartScenename;
    [SerializeField] private string ControlScenename;
    [SerializeField] private string MenuScenename;

    public void StartGame()
    {
        //Debug.Log("Start");
        SceneManager.LoadScene(StartScenename);
        ;
    }

    public void Control()
    {
        SceneManager.LoadScene(ControlScenename);
    }

    public void Mainmenu()
    {
        SceneManager.LoadScene(MenuScenename);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }

}
