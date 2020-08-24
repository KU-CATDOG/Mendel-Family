using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceController : MonoBehaviour
{
    GameObject faceOn;

    // Start is called before the first frame update
    void Start()
    {
        faceOn = this.gameObject.transform.GetChild(UnityEngine.Random.Range(0, 10)).gameObject;
        faceOn.SetActive(true);

        if (UnityEngine.Random.Range(0, 2) == 0)
        faceOn.GetComponent<SpriteRenderer>().flipX = true;
    }
}
