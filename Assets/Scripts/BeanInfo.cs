﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BeanInfo : MonoBehaviour
{
    public bool fixedBean;

    // Genotype variables in arrays. Dominant gene is 0.
    // Bean color: YY == 00, Yy == 01, yy == 11, Y_ == 09
    public int[] y = new int[2];
    // Bean shape: RR == 00, Rr = 01, rr == 11, R_ == 09
    public int[] r = new int[2];

    void Start()
    {
        if (y[0] == 0 && y[1] == 0)
            this.transform.GetChild(0).gameObject.SetActive(true);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bean")
            Physics.IgnoreCollision(col.collider, this.GetComponent<Collider>());
    }

    public int[] Genotype(int arrNum)
    {
        if (arrNum == 0)
            return y;
        else if (arrNum == 1)
            return r;
        else
            return null;
    }
}
