using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanController : MonoBehaviour
{
    public Material[] beanMaterial;
    public Sprite[] beanSprite;
    BeanInfo beanInfo;

    void Start()
    {
        beanInfo = GetComponent<BeanInfo>();

        int ySum = beanInfo.y[0] + beanInfo.y[1];
        int rSum = beanInfo.r[0] + beanInfo.r[1];
        int index = 0; // 0 - YYRR, 1 - yyRR, 2 - YYrr, 3 - yyrr; YY and RR includes Yy and Rr

        if (ySum == 2)   // If yy
        {
            index++;
        }
        if (rSum == 2)  // if rr
        {
            index += 2;
        }

        gameObject.GetComponent<SpriteRenderer>().material = beanMaterial[index];
        gameObject.GetComponent<SpriteRenderer>().sprite = beanSprite[index];
    }
}
