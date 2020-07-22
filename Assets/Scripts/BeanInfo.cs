﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanInfo : MonoBehaviour
{
    public bool fixedBean;

    // Genotype variables in arrays. Dominant gene comes first.

    // Bean color
    public int[] y = new int[2];

    // Bean shape
    public int[] r = new int[2];

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bean")
            Physics.IgnoreCollision(col.collider, this.GetComponent<Collider>());
    }
}
