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
                beans[i] = slots[i].GetComponentInChildren<SlotController>().occupyingBean;

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
                        GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>().level++;
                        GameObject.Find("UIController").GetComponent<UIController>().Success();
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
        for (int k = 0; k < 2; k++)
        {
            result += CheckAnswer(k);

            // Reset gene data
            for (int l = 0; l < slots.Length; l++)
            {
                if (slots[l].GetComponentInChildren<SlotController>().occupyingBean.GetComponent<BeanInfo>().undecided[k] == true)
                    slots[l].GetComponentInChildren<SlotController>().occupyingBean.GetComponent<BeanInfo>().Genotype(k)[1] = 9;
            }
        }

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
            if (slots[j].GetComponentInChildren<SlotController>().parents[0] == null)
                continue;
            else
            {
                if (slots[j].GetComponentInChildren<SlotController>().parents[1] == null)
                    slots[j].GetComponentInChildren<SlotController>().parents[1] = slots[j].GetComponentInChildren<SlotController>().parents[0];

                parentA = slots[j].GetComponentInChildren<SlotController>().parents[0].GetComponentInChildren<SlotController>().occupyingBean;
                parentB = slots[j].GetComponentInChildren<SlotController>().parents[1].GetComponentInChildren<SlotController>().occupyingBean;
                child = slots[j].GetComponentInChildren<SlotController>().occupyingBean;
                
                // Check if the first parent has the first gene of a child
                if (parentA.GetComponent<BeanInfo>().Genotype(arrNum)[0] == child.GetComponent<BeanInfo>().Genotype(arrNum)[0] || parentA.GetComponent<BeanInfo>().Genotype(arrNum)[1] == child.GetComponent<BeanInfo>().Genotype(arrNum)[0] || parentA.GetComponent<BeanInfo>().Genotype(arrNum)[1] == 9)
                {
                    // Check if the second parent has the second gene of a child
                    if (parentB.GetComponent<BeanInfo>().Genotype(arrNum)[0] == child.GetComponent<BeanInfo>().Genotype(arrNum)[1] || parentB.GetComponent<BeanInfo>().Genotype(arrNum)[1] == child.GetComponent<BeanInfo>().Genotype(arrNum)[1] || parentB.GetComponent<BeanInfo>().Genotype(arrNum)[1] == 9)
                        continue;
                    // If the child's genes are undecided
                    else if (child.GetComponent<BeanInfo>().Genotype(arrNum)[0] == 0 && child.GetComponent<BeanInfo>().Genotype(arrNum)[1] == 9)
                    {
                        // If the parents are homozygous
                        if (parentA.GetComponent<BeanInfo>().Genotype(arrNum)[0] == parentA.GetComponent<BeanInfo>().Genotype(arrNum)[1] && parentB.GetComponent<BeanInfo>().Genotype(arrNum)[0] == parentB.GetComponent<BeanInfo>().Genotype(arrNum)[1])
                        {
                            // YY
                            if (parentA.GetComponent<BeanInfo>().Genotype(arrNum)[0] == parentB.GetComponent<BeanInfo>().Genotype(arrNum)[0])
                                child.GetComponent<BeanInfo>().Genotype(arrNum)[1] = parentA.GetComponent<BeanInfo>().Genotype(arrNum)[0];
                            // Yy
                            else
                                child.GetComponent<BeanInfo>().Genotype(arrNum)[1] = 1;
                            // Child's genes should be reset later
                        }
                        continue;
                    }
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
                    // If the child's genes are undecided
                    else if (child.GetComponent<BeanInfo>().Genotype(arrNum)[0] == 0 && child.GetComponent<BeanInfo>().Genotype(arrNum)[1] == 9)
                    {
                        // If the parents are homozygous
                        if (parentA.GetComponent<BeanInfo>().Genotype(arrNum)[0] == parentA.GetComponent<BeanInfo>().Genotype(arrNum)[1] && parentB.GetComponent<BeanInfo>().Genotype(arrNum)[0] == parentB.GetComponent<BeanInfo>().Genotype(arrNum)[1])
                        {
                            // YY
                            if (parentA.GetComponent<BeanInfo>().Genotype(arrNum)[0] == parentB.GetComponent<BeanInfo>().Genotype(arrNum)[0])
                                child.GetComponent<BeanInfo>().Genotype(arrNum)[1] = parentA.GetComponent<BeanInfo>().Genotype(arrNum)[0];
                            // Yy
                            else
                                child.GetComponent<BeanInfo>().Genotype(arrNum)[1] = 1;
                            // Child's genes should be reset later
                        }
                        continue;
                    }
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
