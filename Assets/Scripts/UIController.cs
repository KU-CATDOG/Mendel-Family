using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Title Scene
    public GameObject option;
    bool music = true;
    bool sound = true;

    // In Game Pause Menu
    public GameObject pausePanel;
    public GameObject pauseBtn;
    public GameObject hintBtn;


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
    public void Stage1Btn()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Stage2Btn()
    {
        // Need to change later
        Debug.Log("Load Level 2 Scene");
    }

    public void Stage3Btn()
    {
        // Need to change later
        Debug.Log("Load Level 3 Scene");
    }

    // Level Select Scene
    public void LevelSelectBtn()
    {
        SceneManager.LoadScene("Main"); // Need to change later
    }

    public void Level2()
    {
        SceneManager.LoadScene("Main 1");
    }

    public void Level3()
    {
        SceneManager.LoadScene("Main 2");
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
        SceneManager.LoadScene("Level1");
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
