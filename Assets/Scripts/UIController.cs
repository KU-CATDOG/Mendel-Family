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

    // In Game
    public GameObject pausePanel;
    public GameObject successPanel;
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
        option.SetActive(!option.activeInHierarchy);
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

    public void NextLvlBtn()
    {
        pauseBtn.SetActive(true);
        hintBtn.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
