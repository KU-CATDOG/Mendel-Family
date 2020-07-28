using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public void TitlePlayBtn()
    {
        SceneManager.LoadScene("Stage");
    }

    public void TitleOptionBtn()
    {
        // Load Option
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

    public void StageSelectBtn()
    {
        SceneManager.LoadScene("Level1");   // Need to change later
    }

    public void LevelSelectBtn()
    {
        SceneManager.LoadScene("Main"); // Need to change later
    }
}
