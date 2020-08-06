using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour
{
    GameObject manager;
    public GameObject managerPrefab;

    // Title Scene
    public GameObject option;
    bool music = true;
    bool sound = true;

    // In Game Pause Menu
    public GameObject pausePanel;
    public GameObject pauseBtn;
    public GameObject hintBtn;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("LevelManager");
        if (manager == null)
        {
            Instantiate(managerPrefab);
        }
    }

    // Title Scene
    public void TitlePlayBtn()
    {
        SceneManager.LoadScene("Stage");
    }

    public void TitleOptionBtn()
    {
        if (option.activeInHierarchy)
        {
            option.SetActive(false);
        }
        else
        {
            option.SetActive(true);
        }
    }

    public void MusicBtn()
    {
        // Music On/Off
        if (music)
        {
            Debug.Log("Music Off");
            music = false;
        }
        else
        {
            Debug.Log("Music On");
            music = true;
        }
    }

    public void SoundBtn()
    {
        // Sound effect On/Off
        if (sound)
        {
            Debug.Log("Sound Off");
            sound = false;
        }
        else
        {
            Debug.Log("Sound On");
            sound = true;
        }
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

    // In Game Pause
    public void PauseBtn()
    {
        pausePanel.SetActive(true);
        pauseBtn.SetActive(false);
        hintBtn.SetActive(false);
        // Bean should be not dragable
    }

    public void HintBtn()
    {
        // Need to change later
        Debug.Log("Hint");
    }

    public void ResumeBtn()
    {
        pausePanel.SetActive(false);
        pauseBtn.SetActive(true);
        hintBtn.SetActive(true);
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
}
