using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Swing : MonoBehaviour
{
    // Speed at which the object is propelled when triggered
    [SerializeField] private float propelSpeed = 10f;
    [SerializeField] private BoxCollider Box;

    private void Awake()
    {
        Box = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("Clicking");
            Box.enabled = true;
        }
        else
        {
            Box.enabled = false;
        }
    }
    void OnTriggerEnter(Collider Ballcol)
        {
            // Check if the entering object has the tag "Ball"
            if (Ballcol.CompareTag("Ball"))
            {
                Vector3 awayFromPlayer = Ballcol.transform.position - transform.position;// Calculate the direction the ball collide with player object
                awayFromPlayer.Normalize();// Normalize the direction to make it a unit vector
                Rigidbody ballRigidbody = Ballcol.GetComponent<Rigidbody>();// Get the Rigidbody component of the ball
                ballRigidbody.velocity = awayFromPlayer * propelSpeed;// Add velocity to the ball
                Quaternion newRotation = Quaternion.LookRotation(-awayFromPlayer);// Change the rotation of the ball to face away from the player object
                ballRigidbody.rotation = newRotation;
            }
    }

    
    
}

/*
{
    [SerializeField] Transform Player; // Reference to the player's transform
    [SerializeField] private float SwingSpeed = 90f; // Speed at which the bat swings (degrees per second)
    [SerializeField] private float SwingRadius = 2f; // Radius of the circular swing path
    [SerializeField] private float MaxSwingAngle = 90f; // Maximum swing angle in degrees
    [SerializeField] private float ReturnSpeed = 45f; // Speed at which the bat returns to the original position

    private Vector3 OriginalPosition; // Original position of the bat relative to the player
    private Quaternion OriginalRotation; // Original rotation of the bat relative to the player
    private bool IsSwinging = false; // Flag to track if the bat is currently swinging
    private bool IsReturning = false; // Flag to track if the bat is returning to the original position
    private float CurrentSwingAngle = 0f; // Current swing angle

    private void Start()
    {
        OriginalPosition = transform.localPosition;
        OriginalRotation = transform.localRotation;
    }

    private void Update()
    {
        // Check for input to start swinging
        if (Input.GetMouseButtonDown(0) && !IsSwinging && !IsReturning)
        {
            StartSwing();
        }

        if (IsSwinging)
        {
            SwingBat();
        }

        if (IsReturning)
        {
            ReturnToOriginalPosition();
        }
    }

    private void StartSwing()
    {
        IsSwinging = true;
    }

    private void SwingBat()
    {
        // Calculate the rotation angle for this frame
        float swingAngle = SwingSpeed * Time.deltaTime;

        // Add the swing angle to the current swing angle
        CurrentSwingAngle += swingAngle;

        // Clamp the current swing angle to the maximum swing angle
        CurrentSwingAngle = Mathf.Clamp(CurrentSwingAngle, 0f, MaxSwingAngle);

        // Calculate the new position on the circular path
        Vector3 newPosition = OriginalPosition + Quaternion.Euler(0f, CurrentSwingAngle, 0f) * (Vector3.forward * SwingRadius);

        // Calculate the new rotation based on the swing angle
        Quaternion newRotation = OriginalRotation * Quaternion.Euler(0f, CurrentSwingAngle, 0f);

        // Apply the new position and rotation to the bat relative to the player
        transform.localPosition = newPosition;
        transform.localRotation = newRotation;

        // If we reached the maximum swing angle, stop swinging and start returning
        if (CurrentSwingAngle >= MaxSwingAngle)
        {
            CurrentSwingAngle = MaxSwingAngle;
            IsSwinging = false;
            IsReturning = true;
        }
    }

    private void ReturnToOriginalPosition()
    {
        // Calculate the rotation angle for returning to the original position
        float returnAngle = ReturnSpeed * Time.deltaTime;

        // Subtract the return angle from the current swing angle
        CurrentSwingAngle -= returnAngle;

        // Ensure that the angle does not go below zero
        if (CurrentSwingAngle <= 0f)
        {
            CurrentSwingAngle = 0f;
            IsReturning = false;
        }

        // Calculate the new position on the circular path for returning
        Vector3 returnPosition = OriginalPosition + Quaternion.Euler(0f, CurrentSwingAngle, 0f) * (Vector3.forward * SwingRadius);

        // Calculate the new rotation based on the return angle
        Quaternion returnRotation = OriginalRotation * Quaternion.Euler(0f, CurrentSwingAngle, 0f);

        // Apply the new position and rotation to the bat relative to the player for returning
        transform.localPosition = returnPosition;
        transform.localRotation = returnRotation;
    }
}
*/
