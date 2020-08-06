using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    LevelManager manager;
    LevelData data;
    Element[] currentLevel;

    public GameObject[] elementPrefab;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        data = GetComponent<LevelData>();

        data.Parse(manager.csvFile);
        currentLevel = data.GetElements(manager.level);

        GenerateLevel();
    }

    void GenerateLevel()
    {
        for (int i = 0; i < currentLevel.Length; i++)
        {
            GameObject element = Instantiate(elementPrefab[currentLevel[i].type], currentLevel[i].pos, Quaternion.identity);
            if (currentLevel[i].type != 2)
            {
                element.GetComponent<BeanInfo>().y = currentLevel[i].y;
                element.GetComponent<BeanInfo>().r = currentLevel[i].r;
            }
        }
    }
}
