using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FMODUnity;
public class MainMenu : MonoBehaviour
{
    public Button continueButton;
    public GameObject difficultyPanel;
    public GameObject settingsPanel;
    bool settingsOpen;
    public GameObject[] initialButtons;
    public GameObject[] diffButtons;
    public float[] settingValues = new float[4];
    public GameObject xButton;
    public GameObject leavePanel;
    public StudioEventEmitter buttonSFX;

    public void HideInitialButton(bool hide)
    {
        if (hide)
        {
            for (int i = 0; i < initialButtons.Length; i++)
            {
                initialButtons[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < initialButtons.Length; i++)
            {
                initialButtons[i].SetActive(true);
            }
        }
    }

    public void ShowLeavePanel()
    {
        leavePanel.SetActive(true);
    }

    public void DeactivateDiffButtons(bool hide)
    {
        if (hide)
        {
            difficultyPanel.SetActive(false);
        }
        else
        {
            difficultyPanel.SetActive(true);
        }
    }


    private void Start()
    {
        if (GameManager.Instance && GameManager.Instance.currentVersion != PlayerPrefs.GetFloat("SavedVersion", 0))
        {
            Debug.Log("Saved version doesnt match current version. Saved version is " + PlayerPrefs.GetFloat("SavedVersion") + " and current version is " +GameManager.Instance.currentVersion + ". Deleting save");
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetFloat("SavedVersion", GameManager.Instance.currentVersion);
        }
        else if ((PlayerPrefs.GetInt("CurrentLevel") == 2 || PlayerPrefs.GetInt("CurrentLevel") == 3 || PlayerPrefs.GetInt("CurrentLevel") == 4 || SceneManager.GetActiveScene().name == "Intro") && continueButton)
        {
            continueButton.interactable = true;
        }
    }
    
    public void ShowSettingsPanel(bool open)
    {
        buttonSFX.Play();
        if (open)
        {
            settingsPanel.SetActive(true);
            settingsOpen = true;
        }
        else
        {
            settingsPanel.SetActive(false);
            settingsOpen = false;
        }
    }

    public void ShowDifficulties()
    {
        buttonSFX.Play();
        HideInitialButton(true);
        difficultyPanel.SetActive(true);
        xButton.SetActive(true);
    }

    public void ChooseEasy()
    {
        buttonSFX.Play();
        GoToGame();
    }
    public void ChooseNormal()
    {
        buttonSFX.Play();
        GameManager.Instance.normal = true;
        GoToGame();
    }
    public void ChooseHard()
    {
        buttonSFX.Play();
        GameManager.Instance.hard = true;
        GoToGame();
    }
    public void ChooseNightmare()
    {
        buttonSFX.Play();
        GameManager.Instance.nightmare = true;
        GoToGame();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "MainMenu")
        {
            if (settingsOpen)
            {
                ShowSettingsPanel(false);
            }
            else
            {
                ResumeGame();
            }
            
        }
    }

    public void OpenDificultyLevel()
    {

    }

    public void GoToGame() //for new game
    {
        buttonSFX.Play();
        GameManager.Instance.objectsToDestroyByLoad.Clear();
        GameManager.Instance.discartList.Clear();
        GameManager.Instance.toLoad = false;
        Time.timeScale = 1;
        settingValues[0] = PlayerPrefs.GetFloat("MouseSensivity", 0.75f); //ainda nao fizemos o setfloat no menu
        settingValues[1] = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        settingValues[2] = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        settingValues[3] = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        PlayerPrefs.DeleteAll();
        //below we are saving what we dont want to lose
        PlayerPrefs.SetFloat("SavedVersion", GameManager.Instance.currentVersion);
        PlayerPrefs.SetFloat("MouseSensivity", settingValues[0]);
        PlayerPrefs.SetFloat("SFXVolume", settingValues[1]);
        PlayerPrefs.SetFloat("MusicVolume", settingValues[2]);
        PlayerPrefs.SetFloat("MasterVolume", settingValues[3]);

        if (!GameManager.Instance.normal && !GameManager.Instance.hard && !GameManager.Instance.nightmare)
        {
            //easy difficulty
            PlayerPrefs.SetInt("DifficultyLevel", 0); //0 is for easy
        }
        else if (GameManager.Instance.normal && !GameManager.Instance.hard && !GameManager.Instance.nightmare)
        {
            //normal difficulty
            PlayerPrefs.SetInt("DifficultyLevel", 1); //1 is for normal
        }
        else if (!GameManager.Instance.normal && GameManager.Instance.hard && !GameManager.Instance.nightmare)
        {
            //hard difficulty
            PlayerPrefs.SetInt("DifficultyLevel", 2); //2 is for hard
        }
        else if (!GameManager.Instance.normal && !GameManager.Instance.hard && GameManager.Instance.nightmare)
        {
            //nightmare difficulty
            PlayerPrefs.SetInt("DifficultyLevel", 1); //3 is for nightmarish hell ordeal from oblivion
        }


        //and then loading the scene
        SceneManager.LoadScene("StraightMap");
    }
    public void Leave()
    {
        buttonSFX.Play();
        Application.Quit();
    }
    public void ReturnToMainMenu()
    {
        buttonSFX.Play();
        Time.timeScale = 1;
        if (GameManager.Instance)
        {
            Destroy(GameManager.Instance.gameObject);
        }
        
        SceneManager.LoadScene(0);
    }
    public void ContinueGame()
    {
        buttonSFX.Play();
        switch (PlayerPrefs.GetInt("DifficultyLevel"))
        {
            case 0:
                //nothing
                break;

            case 1:
                GameManager.Instance.normal = true;
                break;

            case 2:
                GameManager.Instance.hard = true;
                break;

            case 3:
                GameManager.Instance.nightmare = true;
                break;
            
        }
        Time.timeScale = 1;
        GameManager.Instance.toLoad = true;
        if (PlayerPrefs.GetInt("CurrentLevel") == 2)
        {
            SceneManager.LoadScene("SniperMap");
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 3)
        {
            SceneManager.LoadScene("HiveMap");
        }
        if (PlayerPrefs.GetInt("CurrentLevel") == 4)
        {
            SceneManager.LoadScene("HiveMap"); //while we don`t have map 3
        }
    }

    public void ResumeGame()
    {
        buttonSFX.Play();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            Time.timeScale = 0;
        }
        
    }

    public void RestartPlay()
    {
        buttonSFX.Play();
        Time.timeScale = 1;
        if (GameManager.Instance)
        {
            GameManager.Instance.killedMonsters = 0;
            GameManager.Instance.collectedItems = 0;
            GameManager.Instance.TimeSpent = 0;
        }
        

        if (GameManager.Instance && !GameManager.Instance.nightmare)
        {

            GameManager.Instance.discartList.Clear();
            GameManager.Instance.toLoad = true;
            if (SceneManager.GetActiveScene().name == "StraightMap")
            {
                SceneManager.LoadScene("StraightMap");
            }
            else if (SceneManager.GetActiveScene().name == "SniperMap")
            {
                SceneManager.LoadScene("SniperMap");
            }
            else if (SceneManager.GetActiveScene().name == "HiveMap")
            {
                SceneManager.LoadScene("HiveMap");
            }
        }
        else
        {
            //GameManager.Instance.discartList.Clear();
            if (GameManager.Instance)
            {
                GameManager.Instance.toLoad = false;
            }
            

        }

        if (!GameManager.Instance)
        {
            if (SceneManager.GetActiveScene().name == "StraightMap")
            {
                SceneManager.LoadScene("StraightMap");
            }
            else if (SceneManager.GetActiveScene().name == "SniperMap")
            {
                SceneManager.LoadScene("SniperMap");
            }
            else if (SceneManager.GetActiveScene().name == "HiveMap")
            {
                SceneManager.LoadScene("HiveMap");
            }
        }
        
    }

    void PlayButtonSFX()
    {
        buttonSFX.Play();
    }

}
