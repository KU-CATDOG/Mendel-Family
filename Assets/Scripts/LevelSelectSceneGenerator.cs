using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectSceneGenerator : MonoBehaviour
{
    public Text stageName;
    public Button[] btns;

    public Sprite lockedSprite;

    public int unlockedLevel = 0;

    LevelManager levelManager;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        GenerateScene();

        unlockedLevel = PlayerPrefs.GetInt(levelManager.csvFile, 1);

        for (int i = 0; i < btns.Length; i++)
        {
            if (i >= unlockedLevel)
            {
                btns[i].image.sprite = lockedSprite;
                btns[i].GetComponentInChildren<Text>().enabled = false;
                btns[i].interactable = false;
            }
        }
    }

    void GenerateScene()
    {
        // Stage name text
        if (levelManager.csvFile == "Stage1")
            stageName.text = "Stage 1";
        if (levelManager.csvFile == "Stage2")
            stageName.text = "Stage 2";
        if (levelManager.csvFile == "Stage3")
            stageName.text = "Stage 3";

        // Need to change background image based on stage
        // Need to enable/disable level btns based on completion data
    }
}
