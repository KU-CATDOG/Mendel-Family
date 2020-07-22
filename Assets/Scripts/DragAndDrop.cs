using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Camera cam;

    [SerializeField]
    GameObject target;
    bool clicked = false;

    Vector3 screenPosition;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);

        // Mouse rightclick
        if (Input.GetMouseButton(0))
        {
            // Set target
            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
            {
                // check if the bean is already allocated in the puzzle
                if (hit.collider.tag == "Bean" && hit.collider.GetComponent<BeanInfo>().fixedBean == false)
                {
                    target = hit.transform.gameObject;
                }
            }

            // Click target
            if (target != null)
            {
                clicked = true;
                screenPosition = cam.WorldToScreenPoint(target.transform.position);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            clicked = false;
            target = null;
        }

        if (clicked)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);


            Vector3 movePos = cam.ScreenToWorldPoint(mousePos);

            target.transform.position = movePos;
        }
    }
}
