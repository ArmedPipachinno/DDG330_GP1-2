using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float WalkSpeed = 1.0f;
    [SerializeField] private float RunSpeed = 2.0f;
    [SerializeField] private Vector3 LimitedArea;

    [SerializeField] private AbilitiesManager PlayerAbilities;//[SerializeField] private string SpeedAbilities = "SpeedBoost";

    void Update()
    {
        bool run = Input.GetKey(KeyCode.LeftShift);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float targetSpeed = run ? RunSpeed : WalkSpeed;

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }

        Vector3 velocity = moveDirection * targetSpeed;

        // Calculate the new position based on input and speed
        Vector3 newPosition = transform.position + velocity * Time.deltaTime;
        transform.position = newPosition;
        //if (transform.position.x <= LimitedArea[0].x)
        //{
        //    Debug.Log("Out of range");
        //    transform.position = -newPosition;
        //}
        ////else if (transform.position.x == LimitedArea[1].x)
        ////{
        ////    Debug.Log("Out of range");
        ////    transform.position = newPosition;
        ////}
        //else
        //{
        //    // Update the position of the GameObject
        //    transform.position = -newPosition;
        //}

        Vector3 pos = transform.position;

        if (transform.position.x <= -LimitedArea.x)
        {
            pos.x = -LimitedArea.x;
        }

        if (transform.position.x >= LimitedArea.x)
        {
            pos.x = LimitedArea.x;
        }

        if (transform.position.z <= -LimitedArea.z)
        {
            pos.z = -LimitedArea.z;
        }

        if (transform.position.z >= LimitedArea.z)
        {
            pos.z = LimitedArea.z;
        }

        transform.position = pos;
        ////else if (transform.position.x == LimitedArea[1].x)
        ////{
        ////    Debug.Log("Out of range");
        ////    transform.position = newPosition;
        ////}
        //else
        //{
        //    // Update the position of the GameObject
        //    transform.position = -newPosition;
        //}

        Point_To_Mouse();
    }

    private void Point_To_Mouse()
    {
        Vector3 mousePosition = Input.mousePosition;

        // Set the z-coordinate to the distance from the camera to the object to ensure correct conversion
        mousePosition.z = Vector3.Distance(transform.position, Camera.main.transform.position);

        // Convert the mouse position from screen space to world space
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Get the direction from the object to the mouse position
        Vector3 targetDirection = targetPosition - transform.position;

        // Calculate the rotation angle in radians around the Y-axis
        float angle = Mathf.Atan2(targetDirection.x, targetDirection.z);

        // Convert the angle from radians to degrees and rotate the object around Y-axis
        float angleInDegrees = angle * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, angleInDegrees, 0));
    }

    public void ActivateSpeed()
    {
        WalkSpeed = WalkSpeed * 2;
        RunSpeed = RunSpeed * 1.5f;
    }

}

/*
public class Movement : MonoBehaviour
{
    //[SerializeField] Camera CamVal;
    [SerializeField] Rigidbody RigidPlay;
    [SerializeField] private float WalkSpeed = 1.0f;
    [SerializeField] private float RunSpeed = 2.0f;
    //private float _Accel = .75f;
    //[SerializeField] private float RotationSpeed = 15.0f;

    //private Vector3 mouseRotation;

    private void Awake()
    {
        RigidPlay = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool run = Input.GetKey(KeyCode.LeftShift);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float targetSpeed = run ? RunSpeed : WalkSpeed;

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            run = true;
        }

        Vector3 velocity = moveDirection * targetSpeed;

        Vector3 newPosition = RigidPlay.transform.position + velocity * Time.deltaTime;
        RigidPlay.velocity = newPosition;//newPosition;
        Point_To_Mouse();
    }

    //float cameraHorizontalAngle = _CurtHoriAngle;
    ////Rotate the player character towards the camera direction
    //Quaternion TargetRotation = Quaternion.Euler(0f, 0f //cameraHorizontalAngle//, 0f);
    //transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, Time.deltaTime * RotationSpeed);

    private void Point_To_Mouse()
    {
        //// Get the mouse position in screen space
        //Vector3 mousePosition = Input.mousePosition;

        //// Set the z-coordinate to the distance from the camera to the object to ensure correct conversion
        //mousePosition.z = Vector3.Distance(transform.position, Camera.main.transform.position);

        //// Convert the mouse position from screen space to world space
        //Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        //// Get the direction from the object to the mouse position
        //Vector3 targetDirection = targetPosition;// - transform.position;

        //// Calculate the rotation angle in radians
        //float angle = Mathf.Atan2(targetDirection.y, targetDirection.x);

        //// Convert the angle from radians to degrees and rotate the object
        //float angleInDegrees = angle * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0, -angleInDegrees, 0));

        // Get the mouse position in screen space
        // Get the mouse position in screen space
        Vector3 mousePosition = Input.mousePosition;

        // Set the z-coordinate to the distance from the camera to the object to ensure correct conversion
        mousePosition.z = Vector3.Distance(transform.position, Camera.main.transform.position);

        // Convert the mouse position from screen space to world space
        Vector3 targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Get the direction from the object to the mouse position
        Vector3 targetDirection = targetPosition - transform.position;

        // Calculate the rotation angle in radians around the Y-axis
        float angle = Mathf.Atan2(targetDirection.x, targetDirection.z);

        // Convert the angle from radians to degrees and rotate the object around Y-axis
        float angleInDegrees = angle * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, angleInDegrees, 0));
    }
}
*/
