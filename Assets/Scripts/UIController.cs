﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    GameObject manager;
    public GameObject managerPrefab;

    // Title Scene
    public GameObject option;
    bool music;
    bool sound;

    // In Game
    public GameObject pausePanel;
    public GameObject successPanel;
    public GameObject pauseBtn;
    public GameObject hintBtn;

    // Tutorial
    public GameObject[] tutorialPanel;
    public int tutorialIndex = 0;
    int[] stage1Tutorial = { 1, 2, 3, 4, 5, 9 };

    // Audio
    AudioSource audioSource;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("LevelManager");
        if (manager == null)
        {
            manager = Instantiate(managerPrefab);
        }

        // Audio
        audioSource = GetComponent<AudioSource>();
        sound = manager.GetComponent<LevelManager>().soundEffect;
        music = manager.GetComponent<LevelManager>().audioSource.isActiveAndEnabled;

        // Tutorial
        if (SceneManager.GetActiveScene().buildIndex == 3 && manager.GetComponent<LevelManager>().csvFile == "Stage1")  // Stage1
        {
            for (tutorialIndex = 0; tutorialIndex < stage1Tutorial.Length; tutorialIndex++)
            {
                if (manager.GetComponent<LevelManager>().level == stage1Tutorial[tutorialIndex])
                {
                    tutorialPanel[tutorialIndex].SetActive(true);
                    pauseBtn.SetActive(false);
                    hintBtn.SetActive(false);
                    GameObject.Find("DragDropController").GetComponent<DragAndDrop>().isPaused = true;
                    break;
                }
            }
        }

        if (SceneManager.GetActiveScene().buildIndex == 3 && manager.GetComponent<LevelManager>().csvFile == "Stage2")  // Stage2
        {
            if (manager.GetComponent<LevelManager>().level == 1)
            {
                tutorialPanel[6].SetActive(true);
                pauseBtn.SetActive(false);
                hintBtn.SetActive(false);
                GameObject.Find("DragDropController").GetComponent<DragAndDrop>().isPaused = true;
            }
        }
    }

    // Title Scene
    public void TitlePlayBtn()
    {
        SceneManager.LoadScene("Stage");
    }

    public void TitleOptionBtn()
    {
        option.SetActive(!option.activeInHierarchy);
        option.transform.parent.parent.GetChild(3).gameObject.SetActive(!option.activeInHierarchy);
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void MusicBtn()
    {
        // Music on/off
        manager.GetComponent<LevelManager>().audioSource.enabled = !manager.GetComponent<LevelManager>().audioSource.enabled;
        music = !music;
    }

    public void SoundBtn()
    {
        // Sound effect on/off
        manager.GetComponent<LevelManager>().soundEffect = manager.GetComponent<LevelManager>().soundEffect;
        sound = !sound;
    }

    public void CreditBtn()
    {
        // Load Credit Scene
        Debug.Log("Load Credit Scene");
    }

    // Stage Select Scene
    public void StageBtn()
    {
        manager.GetComponent<LevelManager>().csvFile = EventSystem.current.currentSelectedGameObject.name;
        SceneManager.LoadScene("Level");
    }

    // Level Select Scene
    public void LevelBtn()
    {
        manager.GetComponent<LevelManager>().level = int.Parse(EventSystem.current.currentSelectedGameObject.name);
        SceneManager.LoadScene("Game");
    }

    #region In Game 
    // Tutorial
    public void OkBtn()
    {
        if (manager.GetComponent<LevelManager>().csvFile == "Stage1")
            tutorialPanel[tutorialIndex].SetActive(false);
        else if (manager.GetComponent<LevelManager>().csvFile == "Stage2")
            tutorialPanel[6].SetActive(false);

        pauseBtn.SetActive(true);
        hintBtn.SetActive(true);
        GameObject.Find("DragDropController").GetComponent<DragAndDrop>().isPaused = false;
    }

    // Pause
    public void PauseBtn()
    {
        pausePanel.SetActive(true);
        pauseBtn.SetActive(false);
        hintBtn.SetActive(false);
        GameObject.Find("DragDropController").GetComponent<DragAndDrop>().isPaused = true; // Bean should be not dragable
    }

    public void HintBtn()
    {
        // Need to change later
        Debug.Log("Hint");
    }

    public void ResumeBtn()
    {
        // Unpause
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
        hintBtn.SetActive(true);
        GameObject.Find("DragDropController").GetComponent<DragAndDrop>().isPaused = false;
    }

    public void RestartBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MenuBtn()
    {
        // Need to load current level select scene
        SceneManager.LoadScene("level");
    }

    // Next level after success
    public void Success()
    {
        successPanel.SetActive(true);
        pauseBtn.SetActive(false);
        hintBtn.SetActive(false);
        GameObject.Find("DragDropController").GetComponent<DragAndDrop>().isPaused = true; // Bean should be not dragable
    }

    public void ReplayBtn()
    {
        manager.GetComponent<LevelManager>().level -= 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLvlBtn()
    {
        pauseBtn.SetActive(true);
        hintBtn.SetActive(true);
        if (manager.GetComponent<LevelManager>().level < 16)
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        else
            SceneManager.LoadScene("level");
    }
    #endregion

    // 
    public void BackBtn()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            SceneManager.LoadScene("Title");
        }
        else
        {
            SceneManager.LoadScene("Stage");
        }
    }

    // Audio
    public void SoundEffect()
    {
        if (manager.GetComponent<LevelManager>().soundEffect)
            audioSource.Play();
    }
}
