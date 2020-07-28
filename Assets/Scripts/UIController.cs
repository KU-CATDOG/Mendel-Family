using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public GameObject option;

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
    }

    public void SoundBtn()
    {
        // Sound effect On/Off
    }

    public void CreditBtn()
    {
        // Load Credit Scene
    }

    // Stage Select Scene
    public void StageSelectBtn()
    {
        SceneManager.LoadScene("Level1");   // Need to change later
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
