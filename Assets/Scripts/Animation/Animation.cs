using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator Animate;
    private float AnimSpeed = 0f;
    private float Dir = 0f;
    private float WalkSpd = 1.0f;
    private float RunSpeed = 2.0f;
    private float AccelRate = .75f;
    private int VelozHash;
    private int VeloxHash;
    private const string PunchAnimation = "IsPunching";

    private void Awake()
    {
        TryGetComponent(out Animate);
        VelozHash = Animator.StringToHash("VeloZ");
        VeloxHash = Animator.StringToHash("VeloX");
    }

    void Update()
    {
        bool run = Input.GetKey(KeyCode.LeftShift);
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        float targetSpeed = run ? RunSpeed : WalkSpd;

        AnimSpeed = Mathf.MoveTowards(AnimSpeed, targetSpeed * verticalInput, AccelRate * Time.deltaTime);//_Speed = Mathf.MoveTowards(_Speed, VerticalInput, _Decel * Time.deltaTime);
        Dir = Mathf.MoveTowards(Dir, targetSpeed * horizontalInput, AccelRate * Time.deltaTime); //_Dir = Mathf.MoveTowards(_Dir, HorizontalInput, _Decel * Time.deltaTime);

        Animate.SetFloat(VelozHash, AnimSpeed);
        Animate.SetFloat(VeloxHash, Dir);

        if(Input.GetMouseButtonDown(0))
        {
            Animate.SetBool(PunchAnimation, true);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            Animate.SetBool(PunchAnimation, false);
        }

    }
}
