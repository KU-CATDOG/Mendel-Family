using UnityEngine;

[System.Serializable]
public class Element : MonoBehaviour
{
    public int level;
    public int type;
    public Vector3 pos;
    public int[] y = new int[2];
    public int[] r = new int[2];
}
