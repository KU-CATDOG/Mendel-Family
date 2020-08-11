using UnityEngine;
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

    // In Game Pause Menu
    public GameObject pausePanel;
    public GameObject pauseBtn;
    public GameObject hintBtn;

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
            manager.GetComponent<LevelManager>().audioSource.enabled = false;
            music = false;
        }
        else
        {
            manager.GetComponent<LevelManager>().audioSource.enabled = true;
            music = true;
        }
    }

    public void SoundBtn()
    {
        // Sound effect On/Off
        if (sound)
        {
            manager.GetComponent<LevelManager>().soundEffect = false;
            sound = false;
        }
        else
        {
            manager.GetComponent<LevelManager>().soundEffect = true;
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

    #region In Game 
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
