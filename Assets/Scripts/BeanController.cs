using UnityEngine;

public class BeanController : MonoBehaviour
{
    public Material[] beanMaterial;
    public Sprite[] beanSprite;
    BeanInfo beanInfo;

    void Start()
    {
        beanInfo = GetComponent<BeanInfo>();

        int ySum = beanInfo.Y[0] + beanInfo.Y[1];
        int rSum = beanInfo.R[0] + beanInfo.R[1];
        int rwSum = beanInfo.RW[0] + beanInfo.RW[1];
        int index = 0;

        if (ySum == 2)   // If yy
            index++;
        
        if (rSum == 2)  // if rr
            index += 5;
        
        if (rwSum == 0) // rw red
            index += 2;
        else if (rwSum == 1)    // rw pink
            index += 3;
        else if (rwSum == 2)    // rw white
            index += 4;

        /*
         * 0 - YYRR     Yellow Round
         * 1 - yyRR     Green Round
         * 2 - RWRR     Red Round
         * 3 - RwRR     Pink Round
         * 4 - rwRR     White Round
         * 5 - YYrr     Yellow Wrinkled
         * 6 - yyrr     Green Wrinkled
         * 7 - RWrr     Red Wrinkled
         * 8 - Rwrr     Pink Wrinkled
         * 9 - rwrr     White Wrinkled
         */


        gameObject.GetComponent<SpriteRenderer>().material = beanMaterial[index];
        gameObject.GetComponent<SpriteRenderer>().sprite = beanSprite[index];
    }
}
