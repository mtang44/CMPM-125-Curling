using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class StoneController : MonoBehaviour
{
    private Rigidbody rb;
    private Camera cam;

    private Vector2 mousePosition;

    private bool chargingUp = true; 

    private LineRenderer Ir;

    public float maxForce = 50f;
    public float chargeSpeed = 30f;

    private float currentForce = 0f;
    private bool isCharging = false;
    [SerializeField] private bool hasBeenThrown = false;

    void Start()
    {
        hasBeenThrown = false;
        rb = GetComponent<Rigidbody>();
        Ir = GetComponent<LineRenderer>();
        cam = Camera.main;
    }

    void OnPoint(InputValue value)
    {
        mousePosition = value.Get<Vector2>();
    }

    void OnClick(InputValue value)
    {
        Debug.Log("CLICK EVENT: " + value.isPressed);

        if (!hasBeenThrown)
        {
                
            if (value.isPressed)
            {
                StartCharging();
                isCharging = true;
                chargingUp = true;
            }
            else
            {
                isCharging = false;
                ThrowStone();
            }
        }
    }

    void Update()
    {

        if(!hasBeenThrown)
        {
            AimWithMouse();
            HandleCharging();
            UpdateAimLine();
            Debug.Log("THROW FORCE: " + currentForce);
        }    
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
            if (chargingUp)
            {
                currentForce += chargeSpeed * Time.deltaTime;
            
                if (currentForce >= maxForce)
                {
                    currentForce = maxForce;
                    chargingUp = false;
                }
            }
            else
            {
                currentForce -= chargeSpeed * Time.deltaTime;

                if (currentForce <= 0f)
                {
                    currentForce = 0f;
                    chargingUp = true;
                }
            }
        }
    }

    void ThrowStone()
    {
        Debug.Log("THROW FORCE: " + currentForce);
        rb.AddForce(transform.forward * currentForce, ForceMode.Impulse);

        currentForce = 0f;
        isCharging = false;
        hasBeenThrown = true;
    }

    void UpdateAimLine()
    {
        Vector3 start = transform.position;

        float lineLength = Mathf.Lerp(1f, 4f, currentForce / maxForce);
        Vector3 end = transform.position + transform.forward * lineLength;

        Ir.SetPosition(0, start);
        Ir.SetPosition(1, end);
    }
}