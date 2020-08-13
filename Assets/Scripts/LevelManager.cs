using System.Collections;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level = 1;
    public string csvFile = "Stage1";

    public bool soundEffect = true;

    public AudioClip[] BGM;     // Temp
    public AudioSource audioSource; // Temp

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
