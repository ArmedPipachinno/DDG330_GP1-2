using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class BounceController : MonoBehaviour
{
    Rigidbody BallRigid;
    [SerializeField] private float BounceForce = 10.0f;

    Vector3 BallSpeed;

    private void Awake()
    {
        BallRigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        BallSpeed = BallRigid.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BounceSurface") || collision.gameObject.CompareTag("Ball") || collision.gameObject.CompareTag("Player") ) // BounceSurface
        {

            //// Calculate the angle between the ball's direction and the wall's normal in radians
            //float angle = Mathf.Atan2(Vector3.Dot(BallSpeed, Vector3.Cross(Vector3.up, collision.contacts[0].normal)), Vector3.Dot(BallSpeed, collision.contacts[0].normal));

            //// Convert the angle from radians to degrees
            //float angleInDegrees = angle * Mathf.Rad2Deg;

            //// Log the angle in degrees to the console
            //Debug.Log("Angle with Wall: " + angleInDegrees);

            var Speed = BallSpeed.magnitude;
            Vector3 BounceDirection = Vector3.Reflect(BallSpeed.normalized, collision.contacts[0].normal);

            GetComponent<Rigidbody>().AddForce(BounceDirection * BounceForce, ForceMode.Impulse);
        }
    }
}
