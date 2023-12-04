using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour
{
    private Animator _Animate;
    private float _Speed = 0f;
    private float _Dir = 0f;
    private float _MaxWalk = 1.0f; 
    private float _MaxSpeed = 2.0f;
    private float _Accel = .75f;
    private int _VelozHash;
    private int _VeloxHash;

    private void Awake()
    {
        TryGetComponent(out _Animate);
        _VelozHash = Animator.StringToHash("VeloZ");
        _VeloxHash = Animator.StringToHash("VeloX");
    }

    void Update()
    {
        bool Run = Input.GetKey(KeyCode.LeftShift);
        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        float TargetSpeed = Run ? _MaxSpeed : _MaxWalk;

        _Speed = Mathf.MoveTowards(_Speed, TargetSpeed * VerticalInput, _Accel * Time.deltaTime);//_Speed = Mathf.MoveTowards(_Speed, VerticalInput, _Decel * Time.deltaTime);
        _Dir = Mathf.MoveTowards(_Dir, TargetSpeed * HorizontalInput, _Accel * Time.deltaTime); //_Dir = Mathf.MoveTowards(_Dir, HorizontalInput, _Decel * Time.deltaTime);
        
        _Animate.SetFloat(_VelozHash, _Speed);
        _Animate.SetFloat(_VeloxHash, _Dir);
    }
}
