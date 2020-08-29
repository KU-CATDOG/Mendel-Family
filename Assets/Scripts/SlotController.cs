 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotController : MonoBehaviour
{
    // Two parents are in different pods
    public GameObject[] parents = new GameObject[2];
    public GameObject occupyingBean;

    // Differently colored pods. Has room for improvement.
    public Sprite fixedBeanPod;
    public Sprite fixedBeanPodTop;

    public bool allocated;

    void Start()
    {
        occupyingBean = null;
        allocated = false;

        if (this.gameObject.transform.position.x < 0)
        {
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
        }

        this.gameObject.transform.parent.GetComponent<Animator>().speed = UnityEngine.Random.Range(0.8f, 1.2f);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Bean" && (occupyingBean == null || occupyingBean == other.gameObject) && !other.gameObject.GetComponent<BeanInfo>().clicked)
        {
            if (this.gameObject.GetComponent<SpriteRenderer>().flipX == true)
                other.transform.position = new Vector3(this.transform.position.x - 0.12f, this.transform.position.y + 0.04f, this.transform.position.z - 0.05f);
            else
                other.transform.position = new Vector3(this.transform.position.x + 0.12f, this.transform.position.y + 0.04f, this.transform.position.z - 0.05f);
            occupyingBean = other.gameObject;

            // Change Color of the pod if the bean is fixedBean
            if (occupyingBean.GetComponent<BeanInfo>().fixedBean)
            {
                this.GetComponent<SpriteRenderer>().sprite = fixedBeanPod;
                this.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = fixedBeanPodTop;
            }

            // Make bean upright
            other.transform.rotation = Quaternion.identity;
            other.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;

            // Play allocation effect
            if (!allocated && !other.GetComponent<BeanInfo>().fixedBean)
            {
                this.transform.parent.GetChild(1).GetComponent<ParticleSystem>().Play();
                allocated = true;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bean" && occupyingBean == other.gameObject)
        {
            occupyingBean.transform.position = new Vector3(occupyingBean.transform.position.x, occupyingBean.transform.position.y, -2.5f);
            occupyingBean = null;
            allocated = false;
        }
    }
}
