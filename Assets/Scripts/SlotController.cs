using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    public bool parent;

    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Bean")
        {
            other.transform.position = new Vector3(transform.position.x, transform.position.y, other.transform.position.z);
        }
    }
}
