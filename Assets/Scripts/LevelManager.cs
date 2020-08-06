using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level;
    public string csvFile;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
