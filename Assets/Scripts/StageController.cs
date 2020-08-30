using UnityEngine;
using UnityEngine.UI;

public class StageController : MonoBehaviour
{
    public Button[] btns;
    public Sprite[] lockedSprite;

    int unlockedStage = 1;

    LevelManager manager;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();

        unlockedStage = PlayerPrefs.GetInt("Stage", 1);

        for (int i = 0; i < btns.Length; i++)
        {
            if (i >= unlockedStage)
            {
                btns[i].image.sprite = lockedSprite[i];
                btns[i].GetComponentInChildren<Text>().enabled = false;
                btns[i].interactable = false;
            }
        }
    }
}
