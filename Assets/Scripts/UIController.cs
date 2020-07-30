using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject option;
    bool music = true;
    bool sound = true;

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
