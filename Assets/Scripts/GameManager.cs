using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] slots;
    GameObject[] beans;

    // Relation between beans
    GameObject[] famTree;

    void Start()
    {
        // Parent beans are always in slot 0 and 1
        if (slots[0].GetComponent<SlotController>().parent == false || slots[1].GetComponent<SlotController>().parent == false)
        {
            Debug.LogError("Wrong slots are in parent position");
        }

        beans = new GameObject[slots.Length];
        famTree = new GameObject[12];
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

        for (int j = 2; j < slots.Length; j++)
        {
            // Check if the first parent has the first gene of a child
            if (beans[0].GetComponent<BeanInfo>().y[0] == beans[j].GetComponent<BeanInfo>().y[0] || beans[0].GetComponent<BeanInfo>().y[1] == beans[j].GetComponent<BeanInfo>().y[0])
            {
                // Check if the first parent has the second gene of a child
                if (beans[1].GetComponent<BeanInfo>().y[0] == beans[j].GetComponent<BeanInfo>().y[1] || beans[1].GetComponent<BeanInfo>().y[1] == beans[j].GetComponent<BeanInfo>().y[1])
                    result++;
                else
                    break;
            }
            // Check if the second parent has the first gene of a child
            else if (beans[1].GetComponent<BeanInfo>().y[0] == beans[j].GetComponent<BeanInfo>().y[0] || beans[1].GetComponent<BeanInfo>().y[1] == beans[j].GetComponent<BeanInfo>().y[0])
            {
                // Check if the second parent has the second gene of a child
                if (beans[0].GetComponent<BeanInfo>().y[0] == beans[j].GetComponent<BeanInfo>().y[1] || beans[0].GetComponent<BeanInfo>().y[1] == beans[j].GetComponent<BeanInfo>().y[1])
                    result++;
                else
                    break;
            }
            else
                break;
        }

        if (result == slots.Length - 2)
            return true;
        else
            return false;
    }

    int CheckAnswer(int[] arr)
    {
        int result = 0;

        return result;
    }
}
