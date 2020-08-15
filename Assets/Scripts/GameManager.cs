using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] slots;
    GameObject[] beans;

    void Start()
    {
        beans = new GameObject[slots.Length];
    }

    // press ok button to confirm places
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < slots.Length; i++)
            {
                beans[i] = slots[i].GetComponent<SlotController>().occupyingBean;

                if (beans[i] == null)
                {
                    Debug.Log("Level incomplete");
                    break;
                }

                else if (i == slots.Length - 1)
                {
                    if (ConfirmLevel())
                    {
                        Debug.Log("Game Clear!");
                    }
                    else
                    {
                        Debug.Log("Try Again!");
                    }
                }
            }
        }
    }

    bool ConfirmLevel()
    {
        int result = 0;

        // result = color + shape
        result += CheckAnswer(0) + CheckAnswer(1);

        if (result == 0)
            return true;
        else
            return false;
    }

    int CheckAnswer(int arrNum)
    {
        int result = 0;
        GameObject parentA, parentB, child;

        for (int j = 0; j < slots.Length; j++)
        {
            if (slots[j].GetComponent<SlotController>().parents[0] == null)
                continue;
            else
            {
                if (slots[j].GetComponent<SlotController>().parents[1] == null)
                    slots[j].GetComponent<SlotController>().parents[1] = slots[j].GetComponent<SlotController>().parents[0];

                parentA = slots[j].GetComponent<SlotController>().parents[0].GetComponent<SlotController>().occupyingBean;
                parentB = slots[j].GetComponent<SlotController>().parents[1].GetComponent<SlotController>().occupyingBean;
                child = slots[j].GetComponent<SlotController>().occupyingBean;
                
                // Check if the first parent has the first gene of a child
                if (parentA.GetComponent<BeanInfo>().Genotype(arrNum)[0] == child.GetComponent<BeanInfo>().Genotype(arrNum)[0] || parentA.GetComponent<BeanInfo>().Genotype(arrNum)[1] == child.GetComponent<BeanInfo>().Genotype(arrNum)[0] || parentA.GetComponent<BeanInfo>().Genotype(arrNum)[1] == 9)
                {
                    // Check if the second parent has the second gene of a child
                    if (parentB.GetComponent<BeanInfo>().Genotype(arrNum)[0] == child.GetComponent<BeanInfo>().Genotype(arrNum)[1] || parentB.GetComponent<BeanInfo>().Genotype(arrNum)[1] == child.GetComponent<BeanInfo>().Genotype(arrNum)[1] || parentB.GetComponent<BeanInfo>().Genotype(arrNum)[1] == 9)
                        continue;
                    else if (child.GetComponent<BeanInfo>().Genotype(arrNum)[1] == 9)
                        continue;
                    else
                    {
                        result++;
                        break;
                    }
                }
                // Check if the second parent has the first gene of a child
                else if (parentB.GetComponent<BeanInfo>().Genotype(arrNum)[0] == child.GetComponent<BeanInfo>().Genotype(arrNum)[0] || parentB.GetComponent<BeanInfo>().Genotype(arrNum)[1] == child.GetComponent<BeanInfo>().Genotype(arrNum)[0] || parentB.GetComponent<BeanInfo>().Genotype(arrNum)[1] == 9)
                {
                    // Check if the first parent has the second gene of a child
                    if (parentA.GetComponent<BeanInfo>().Genotype(arrNum)[0] == child.GetComponent<BeanInfo>().Genotype(arrNum)[1] || parentA.GetComponent<BeanInfo>().Genotype(arrNum)[1] == child.GetComponent<BeanInfo>().Genotype(arrNum)[1] || parentA.GetComponent<BeanInfo>().Genotype(arrNum)[1] == 9)
                        continue;
                    else if (child.GetComponent<BeanInfo>().Genotype(arrNum)[1] == 9)
                        continue;
                    else
                    {
                        result++;
                        break;
                    }
                }
                else
                    break;
            }
        }

        return result;
    }
}
