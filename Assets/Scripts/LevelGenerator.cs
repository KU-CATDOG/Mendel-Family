using System.Collections.Generic;
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
                element.GetComponent<BeanInfo>().Y = currentLevel[i].y; // Assign y gene data
                element.GetComponent<BeanInfo>().R = currentLevel[i].r; // Assign r gene data
            }
            else
            {
                slotList.Add(element);  // Create list of slots for gameManager.slots

                if (currentLevel[i].y[0] != 0)  // 0 - Not exist
                {
                    element.GetComponentInChildren<SlotController>().parents[0] = slotList[currentLevel[i].y[0] - 1]; // Add parent data if exist

                    if (currentLevel[i].y[1] != 0)
                    {
                        element.GetComponentInChildren<SlotController>().parents[1] = slotList[currentLevel[i].y[1] - 1]; // Add parent data if exist
                    }
                }
            }
        }

        gameManager.slots = slotList.ToArray();
    }
}
