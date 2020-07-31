using UnityEngine;
using UnityEngine.UI;

public class StageSelectController : MonoBehaviour
{
    public GameObject scrollbar;
    public Text stageName;

    Transform selectedStage;

    float distance;
    float scrollPos = 0f;
    float[] pos;

    void Start()
    {
        pos = new float[transform.childCount];
    }

    void Update()
    {
        distance = 1f / (pos.Length - 1);

        for (int i = 0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scrollPos = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for (int i = 0; i < pos.Length; i++)
            {
                if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++)
        {
            if (scrollPos < pos[i] + (distance / 2) && scrollPos > pos[i] - (distance / 2))
            {
                selectedStage = transform.GetChild(i);
                selectedStage.localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(1, 1), 0.1f);
                selectedStage.GetComponent<Button>().interactable = true;

                for (int j = 0; j < pos.Length; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale = Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(0.8f, 0.8f), 0.1f);
                        transform.GetChild(j).GetComponent<Button>().interactable = false;
                    }
                }
            }
        }

                            stageName.text = selectedStage.name;
    }
}
