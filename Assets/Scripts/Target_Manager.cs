using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target_Manager : MonoBehaviour
{
    [SerializeField] Transform TargetObject;

    void Update()
    {
        // Check if the target object is assigned
        if (TargetObject != null)
        {
            // Make the object face towards the target object
            transform.LookAt(TargetObject.position);
        }
    }
}
