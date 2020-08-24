using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BeanInfo : MonoBehaviour
{
    public bool fixedBean;
    public bool clicked;

    // Genotype variables in arrays. Dominant gene is 0.
    // Bean color: YY == 00, Yy == 01, yy == 11, Y_ == 09
    public int[] y = new int[2];
    // Bean shape: RR == 00, Rr = 01, rr == 11, R_ == 09
    public int[] r = new int[2];
    // Bean color: RR == 00, RW == 01, WW == 11
    public int[] rw = new int[2];

    public bool[] undecided = new bool[2];
    public bool[] Undecided { get; set; }

    void Start()
    {
        for (int i = 0; i < undecided.Length; i++)
        {
            if (Genotype(i)[1] == 9)
                undecided[i] = true;
            else
                undecided[i] = false;
        }

        if (y[0] == y[1] && r[0] == r[1])
            this.transform.GetChild(0).gameObject.SetActive(true);

        clicked = false;
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
        else if (arrNum == 2)
            return rw;
        else
            return null;
    }
}
