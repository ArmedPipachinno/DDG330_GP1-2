using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Target_Manager : MonoBehaviour
{
    [SerializeField] Transform TargetObject;
    [SerializeField] private const string BallTag = "Ball";

    private HPManager HpCheck;
    private Action<Normal_Target_Manager> KillTarget;

    public void Init(Action<Normal_Target_Manager> killAction)
    { KillTarget = killAction; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(BallTag))
        {
            if(HpCheck._HP == 0) //way to activate when certain funtion in other class is called
            { 
                KillTarget?.Invoke(this); 
            }
        }
    }

    public void ResetData()
    {
        //Might need to add more reference to reset certain value from another class
        transform.rotation = Quaternion.identity;
    }
    void Update()
    {
        Vector3 directionToTarget = TargetObject.position - transform.position;
        directionToTarget.y = 0f; // Set the Y component to 0 to prevent tilting along the Y-axis

        // Create the rotation looking at the target
        Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

        // Apply the rotation only around the Y-axis
        transform.rotation = Quaternion.Euler(0f, targetRotation.eulerAngles.y, 0f);
        //// Check if the target object is assigned
        //if (TargetObject != null)
        //{
        //    Vector3 targetPosition = new Vector3(TargetObject.position.x, transform.position.y, TargetObject.position.z);
        //    // Make the object face towards the target object
        //    transform.LookAt(TargetObject.position);
        //}
    }
}
