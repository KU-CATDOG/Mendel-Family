﻿using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    LevelManager levelManager;
    LevelData data;
    GameManager gameManager;
    Element[] currentLevel;

    public GameObject[] elementPrefab;

    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
        data = GetComponent<LevelData>();

        data.Parse(levelManager.csvFile);   // Read level data from the csv file
        currentLevel = data.GetElements(levelManager.level);

        GenerateLevel();
    }

    void GenerateLevel()
    {
        List<GameObject> slotList = new List<GameObject>();

        for (int i = 0; i < currentLevel.Length; i++)
        {
            GameObject element = Instantiate(elementPrefab[currentLevel[i].type], currentLevel[i].pos, Quaternion.identity);
            if (currentLevel[i].type != 2)  // If bean
            {
                element.GetComponent<BeanInfo>().y = currentLevel[i].y; // Assign y gene data
                element.GetComponent<BeanInfo>().r = currentLevel[i].r; // Assign r gene data
            }
            else
            {
                slotList.Add(element);  // Create list of slots for gameManager.slots
            }
        }

        gameManager.slots = slotList.ToArray();
    }
}