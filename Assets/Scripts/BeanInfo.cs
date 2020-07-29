using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanInfo : MonoBehaviour
{
    public bool fixedBean;

    // Genotype variables in arrays. Dominant gene is 0.

    // Bean color: YY == 00, Yy == 01, yy == 11
    public int[] y = new int[2];

    // Bean shape: RR == 00, Rr = 01, rr == 11
    public int[] r = new int[2];

    /*
    Color: genes[0][]
    Shape: genes[1][]
    
    public int[][] genes = new int[2][2];
    */

    void Start()
    {
        if (y[0] == y[1])
            this.transform.GetChild(0).gameObject.SetActive(true);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bean")
            Physics.IgnoreCollision(col.collider, this.GetComponent<Collider>());
    }
}
