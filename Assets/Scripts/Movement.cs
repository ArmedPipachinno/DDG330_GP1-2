using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
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
        RigidPlay.velocity = newPosition;
    }

    //float cameraHorizontalAngle = _CurtHoriAngle;
    ////Rotate the player character towards the camera direction
    //Quaternion TargetRotation = Quaternion.Euler(0f, 0f /*cameraHorizontalAngle*/, 0f);
    //transform.rotation = Quaternion.Slerp(transform.rotation, TargetRotation, Time.deltaTime * RotationSpeed);
}

