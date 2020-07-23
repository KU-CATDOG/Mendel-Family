using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Camera cam;

    [SerializeField]
    GameObject target;
    bool clicked = false;

    Vector3 screenPosition;

    LayerMask layerMask;
    public LayerMask unselectedBean;
    public LayerMask selectedBean;

    void Start()
    {
        cam = Camera.main;
        layerMask = unselectedBean;
    }

    void Update()
    {
       

        // Mouse rightclick
        if (Input.GetMouseButton(0))
        {
            // Set target
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100, layerMask))
            {
                Debug.Log(hit.collider.name);

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
                layerMask = selectedBean;
                target.layer = selectedBean;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            clicked = false;
            layerMask = unselectedBean;
            if (target != null)
            {            
                target.layer = unselectedBean;
                target = null;
            }
        }

        if (clicked)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);


            Vector3 movePos = cam.ScreenToWorldPoint(mousePos);

            target.transform.position = movePos;
        }
    }
}
