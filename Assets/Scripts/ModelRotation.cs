using UnityEngine;

public class ModelRotation : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private float rotationSpeed = 0.3f;
    [SerializeField] private bool enableRotation = true;
    
    private Vector2 lastInputPosition;
    private bool isRotating = false;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (!enableRotation) return;
        
        HandleInput();
    }

    private void HandleInput()
    {
        #if UNITY_EDITOR || UNITY_STANDALONE
        HandleMouseInput();
        #else
        HandleTouchInput();
        #endif
    }

    private void HandleMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (IsInputOnModel(Input.mousePosition))
            {
                isRotating = true;
                lastInputPosition = Input.mousePosition;
            }
        }
        else if (Input.GetMouseButton(0) && isRotating)
        {
            Vector2 delta = (Vector2)Input.mousePosition - lastInputPosition;
            RotateModel(delta.x);
            lastInputPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
        }
    }

    private void HandleTouchInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                if (IsInputOnModel(touch.position))
                {
                    isRotating = true;
                    lastInputPosition = touch.position;
                }
            }
            else if (touch.phase == TouchPhase.Moved && isRotating)
            {
                Vector2 delta = touch.position - lastInputPosition;
                RotateModel(delta.x);
                lastInputPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                isRotating = false;
            }
        }
    }

    private void RotateModel(float deltaX)
    {
        float rotationAmount = deltaX * rotationSpeed;
        transform.Rotate(Vector3.up, rotationAmount, Space.World);
    }

    private bool IsInputOnModel(Vector2 screenPosition)
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            if (mainCamera == null) return false;
        }

        Ray ray = mainCamera.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform == transform || hit.transform.IsChildOf(transform);
        }

        return false;
    }

    public void SetRotationEnabled(bool enabled)
    {
        enableRotation = enabled;
        if (!enabled)
        {
            isRotating = false;
        }
    }
}