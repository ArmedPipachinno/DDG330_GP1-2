using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
//[RequireComponent(typeof(CapsuleCollider))]
public class CameraController : MonoBehaviour
{

    //[SerializeField] Camera Camera;
    [SerializeField] Transform CameraFollowPoint;

    [SerializeField] private float HorizontalSpeed = 100f;
    [SerializeField] private float VerticalSpeed = 100f;

    [SerializeField] private float MaxVertAngle = 75f;
    [SerializeField] private float MinVertAngle = 15f;

    [SerializeField] private float CameraDistance = 10f;

    [SerializeField] private LayerMask ObstacleLayerMask;
    [SerializeField] private float MinRadious = 0.6f;
    [SerializeField] private float SpherecastCastRadious = 0.3f;

    private float CurtHoriAngel = 0f;
    private float CurtVertiAngel = 0f;

    public float _CurtHoriAngel => CurtHoriAngel;

    [SerializeField] private bool InvertY = true;

    private RaycastHit HitObstacle;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        CurtHoriAngel += Input.GetAxis("Mouse X") * HorizontalSpeed * Time.deltaTime;
        CurtHoriAngel = (CurtHoriAngel + 360) % 360;

        float VertDirMult = InvertY ? -1f : 1f;
        CurtVertiAngel += Input.GetAxis("Mouse Y") * VerticalSpeed * VertDirMult * Time.deltaTime;
        CurtVertiAngel = Mathf.Clamp(CurtVertiAngel, MinVertAngle, MaxVertAngle);

        transform.rotation = Quaternion.Euler(CurtVertiAngel, CurtHoriAngel, 0f);

        float FinalArmlength = CameraDistance;
        if (Physics.SphereCast(CameraFollowPoint.position, SpherecastCastRadious, -transform.forward, out HitObstacle, CameraDistance, ObstacleLayerMask))
        {
            FinalArmlength = Mathf.Max(HitObstacle.distance, MinRadious);
        }

        transform.position = CameraFollowPoint.position - (transform.forward * FinalArmlength);
    }

    //verctor3 project on plane
    //target rotation * quan.rotate twords 


    //public void SetFollowTransform(Transform target)
    //{
    //    FollowTransform = target;
    //    PlanarDirection = FollowTransform.forward;
    //    CurrentFollowPosition = FollowTransform.position;
    //}

    //public Transform FollowTransform { get; private set; }
    //public Vector3 PlanarDirection { get; set; }
    //private Vector3 CurrentFollowPosition = new Vector3(0, 0, 0);

    //public Vector3 position
    //{
    //    get
    //    {
    //        get_position_Injected(out var ret);
    //        return ret;
    //    }
    //    set
    //    {
    //        set_position_Injected(ref value);
    //    }
    //}

    //[MethodImpl(MethodImplOptions.InternalCall)]
    //[SpecialName]
    //private extern void get_position_Injected(out Vector3 PosRet);

    //[MethodImpl(MethodImplOptions.InternalCall)]
    //[SpecialName]
    //private extern void set_position_Injected(ref Vector3 PosValue);


}