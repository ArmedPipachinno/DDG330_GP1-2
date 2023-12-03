using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [field: SerializeField] string StartScenename;
    [SerializeField] private string ControlScenename;
    [SerializeField] private string MenuScenename = "MainMenu";
    [SerializeField] private string WinScene = "EndSceneW";
    [SerializeField] private string LoseScene = "EndSceneL";
    [SerializeField] GameObject OptionsMenuUI;
    private bool OptionActive = false;


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
    public void EndW()
    {
        SceneManager.LoadScene(WinScene);
        Time.timeScale = 1;
    }
    public void EndL()
    {
        SceneManager.LoadScene(LoseScene);
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }

    public void ActivateOptions()
    {
        if (OptionActive) 
        { 
            OptionActive = false;
            OptionsMenuUI.SetActive(false); }
        else
        {
            OptionActive = true;
            OptionsMenuUI.SetActive(true);
        }
    }



}
