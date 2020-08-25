using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanController : MonoBehaviour
{
    LevelManager manager;
    public Material[] beanMaterial;
    public Sprite[] beanSprite;
    BeanInfo beanInfo;

    void Start()
    {
        manager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        beanInfo = GetComponent<BeanInfo>();

        int ySum = beanInfo.Y[0] + beanInfo.Y[1];
        int rSum = beanInfo.R[0] + beanInfo.R[1];
        int rwSum = beanInfo.RW[0] + beanInfo.RW[1];
        int index = 0;

        if (ySum == 2)   // If yy
        {
            index++;
        }
        if (rSum == 2)  // if rr
        {
            index += 2;
        }
        /*
        if (rSum == 2)  // if rr
        {
            index += 5;
        }
        if (rwSum == 0)
        {
            if (manager.csvFile == "Stage2")
            {
                index += 2;
            }
        }
        else if (rwSum == 1)
        {
            index += 3;
        }
        else if (rwSum == 2)
        {
            index += 4;
        }
        */


        gameObject.GetComponent<SpriteRenderer>().material = beanMaterial[index];
        gameObject.GetComponent<SpriteRenderer>().sprite = beanSprite[index];
    }
}
