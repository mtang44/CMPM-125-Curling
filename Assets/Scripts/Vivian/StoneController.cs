using UnityEngine;
using UnityEngine.InputSystem;

public class StoneController : MonoBehaviour
{
    private Rigidbody rb;
    private Camera cam;

    private Vector2 mousePosition;

    public float maxForce = 50f;
    public float chargeSpeed = 20f;

    private float currentForce = 0f;
    private bool isCharging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
    }

    void OnPoint(InputValue value)
    {
        mousePosition = value.Get<Vector2>();
    }

    void OnClick(InputValue value)
    {
        Debug.Log("CLICK EVENT: " + value.isPressed);

        if (value.isPressed)
        {
            StartCharging();
        }
        else
        {
            ThrowStone();
        }
    }

    void Update()
    {
        AimWithMouse();
        HandleCharging();
    }

    void AimWithMouse()
    {
        Ray ray = cam.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            Vector3 target = hit.point;

            Vector3 direction = target - transform.position;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                transform.forward = direction;
            }
        }
    }

    void StartCharging()
    {
        isCharging = true;
    }

    void HandleCharging()
    {
        if (isCharging)
        {
            currentForce += chargeSpeed * Time.deltaTime;
            currentForce = Mathf.Clamp(currentForce, 0, maxForce);
        }
    }

    void ThrowStone()
    {
        rb.AddForce(transform.forward * currentForce, ForceMode.Impulse);

        currentForce = 0f;
        isCharging = false;
    }
}