using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimbController : MonoBehaviour
{
    FaceController face;

    GameObject limbOn;
    GameObject dragLimb;

    // Start is called before the first frame update
    void Start()
    {
        limbOn = this.gameObject.transform.GetChild(0).gameObject;
        dragLimb = this.gameObject.transform.GetChild(1).gameObject;

        face = this.gameObject.transform.parent.GetChild(1).GetComponent<FaceController>();
        
        if (face.faceOn.GetComponent<SpriteRenderer>().flipX)
        {
            this.gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x, gameObject.transform.localScale.y, -gameObject.transform.localScale.z);
        }

        limbOn.SetActive(true);
        dragLimb.SetActive(false);
        this.gameObject.transform.GetChild(0).GetComponent<Animator>().speed = UnityEngine.Random.Range(0.8f, 1.2f);
    }
     // Change code structure later
    public void ChangeMotion()
    {
        if (limbOn.activeSelf && !dragLimb.activeSelf && this.GetComponentInParent<BeanInfo>().clicked == true)
        {
            limbOn.SetActive(false);
            dragLimb.SetActive(true);
        }
        else if (this.GetComponentInParent<BeanInfo>().clicked == false)
        {
            limbOn.SetActive(true);
            dragLimb.SetActive(false);
        }
    }
}
