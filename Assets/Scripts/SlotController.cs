using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    public bool parent;

    public GameObject occupyingBean;

    // Start is called before the first frame update
    void Start()
    {
        occupyingBean = null;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Bean" && occupyingBean != null)
        {
            other.transform.position = new Vector3(transform.position.x, transform.position.y, other.transform.position.z);
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
