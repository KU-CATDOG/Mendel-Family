using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] slots;
    GameObject[] beans;

    // Start is called before the first frame update
    void Start()
    {
        // Parent beans are always in slot 0 and 1
        if (slots[0].GetComponent<SlotController>().parent == false || slots[1].GetComponent<SlotController>().parent == false)
        {
            Debug.LogError("Wrong slots are in parent position");
        }        
    }

    // press ok button to confirm places
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            for (int i = 0; i < slots.Length; i++)
            {
                beans[i] = slots[i].GetComponent<SlotController>().occupyingBean;

                if (beans[i] == null)
                {
                    Debug.Log("Level uncompleted");
                    break;
                }

                else if (i == slots.Length - 1)
                    ConfirmLevel();
            }
        }
    }

    void ConfirmLevel()
    {
        for (int j = 2; j < slots.Length; j++)
        {

        }

        if (true)
        {
            Debug.Log("Game Clear!");
        }
        else
        {
            Debug.Log("Try Again!");
        }
    }
}
