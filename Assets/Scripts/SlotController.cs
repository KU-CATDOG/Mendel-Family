using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    // Two parents are in different pods
    public GameObject[] parents = new GameObject[2];
    public GameObject occupyingBean;

    void Start()
    {
        occupyingBean = null;

        if (this.gameObject.transform.position.x < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Bean" && (occupyingBean == null || occupyingBean == other.gameObject))
        {
            if (this.gameObject.GetComponent<SpriteRenderer>().flipX == true)
                other.transform.position = new Vector3(this.transform.position.x - 0.12f, this.transform.position.y + 0.04f, other.transform.position.z);
            else
                other.transform.position = new Vector3(this.transform.position.x + 0.12f, this.transform.position.y + 0.04f, other.transform.position.z);
            occupyingBean = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bean")
        {
            occupyingBean = null;
        }
    }
}
