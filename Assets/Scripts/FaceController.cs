using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceController : MonoBehaviour
{
    public GameObject faceOn;
    GameObject dragFace;

    // Start is called before the first frame update
    void Start()
    {
        faceOn = this.gameObject.transform.GetChild(UnityEngine.Random.Range(0, 10)).gameObject;
        dragFace = this.gameObject.transform.GetChild(UnityEngine.Random.Range(10, 13)).gameObject;
        
        if (UnityEngine.Random.Range(0, 2) == 0)
        {
            faceOn.GetComponent<SpriteRenderer>().flipX = true;
            dragFace.GetComponent<SpriteRenderer>().flipX = true;
        }

        faceOn.SetActive(true);
        dragFace.SetActive(false);
        faceOn.GetComponent<Animator>().speed = UnityEngine.Random.Range(0.8f, 1.2f);
    }

    public void ChangeFace()
    {
        if (faceOn.activeSelf && !dragFace.activeSelf && this.GetComponentInParent<BeanInfo>().clicked == true)
        {
            faceOn.SetActive(false);
            dragFace.SetActive(true);
            this.gameObject.transform.parent.GetChild(2).GetComponent<LimbController>().ChangeMotion();
        }
        else if (this.GetComponentInParent<BeanInfo>().clicked == false)
        {
            faceOn.SetActive(true);
            dragFace.SetActive(false);
            this.gameObject.transform.parent.GetChild(2).GetComponent<LimbController>().ChangeMotion();
        }
    }
}
