using UnityEngine;

public class AnimalTouchDetector : MonoBehaviour
{
    Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        #if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                PartClick part = hit.collider.GetComponent<PartClick>();
                if (part != null) part.OnClicked();
            }
        }
        #endif

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                PartClick part = hit.collider.GetComponent<PartClick>();
                if (part != null) part.OnClicked();
            }
        }
    }
}
