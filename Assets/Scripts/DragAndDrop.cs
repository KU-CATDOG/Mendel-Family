using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    Camera cam;

    [SerializeField] GameObject target;
    bool clicked = false;

    Vector3 screenPosition;

    LayerMask layerMask;
    public LayerMask unselectedBean;
    public LayerMask selectedBean;

    // Pause
    public bool isPaused = false;

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
                // check if the bean is already allocated in the puzzle
                if (hit.collider.tag == "Bean" && hit.collider.GetComponent<BeanInfo>().fixedBean == false && !isPaused)
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
                //target.layer = selectedBean;
                target.layer = 8;
                // To control bean face
                target.GetComponent<BeanInfo>().clicked = true;
                target.GetComponentInChildren<FaceController>().ChangeFace();
                // Make bean upright
                target.transform.rotation = Quaternion.identity;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            clicked = false;
            layerMask = unselectedBean;
            if (target != null)
            {            
                //target.layer = unselectedBean;
                target.layer = 9;
                // To control bean face
                target.GetComponent<BeanInfo>().clicked = false;
                target.GetComponentInChildren<FaceController>().ChangeFace();
                target = null;
            }
        }

        // Move beans
        if (clicked && !isPaused)
        {
            Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);


            Vector3 movePos = cam.ScreenToWorldPoint(mousePos);

            target.transform.position = movePos;
        }
    }
}
