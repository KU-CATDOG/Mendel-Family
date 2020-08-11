using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level;
    public string csvFile;

    public bool soundEffect = true;

    public AudioClip[] BGM;     // Temp
    public AudioSource audioSource; // Temp

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
