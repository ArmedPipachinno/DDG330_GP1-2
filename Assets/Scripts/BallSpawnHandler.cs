using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnHandler : MonoBehaviour
{
    [SerializeField] GameObject BallsGrap; //Object to spawn/launch
    [SerializeField] private Transform LaunchPoint;
    [SerializeField] private float LaunchForce = 25f;
    [SerializeField] private int BallAvailable = 3;

    private GameObject SpawnedObject;
    private bool HoldingObject = false;

    private void Awake()
    {
        SpawnObject();
    }

    private void Update()
    {
        if (SpawnedObject != null && HoldingObject)
        {
            SpawnedObject.transform.position = LaunchPoint.position;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (HoldingObject)
            {
                LaunchObject();
            }
            else if (!HoldingObject & BallAvailable != 0)
            {
                SpawnObject();
                BallAvailable--;
            }
        }
    }

    private void SpawnObject()
    {
        SpawnedObject = Instantiate(BallsGrap, LaunchPoint.position, Quaternion.identity);
        SpawnedObject.transform.parent = transform;
        HoldingObject = true;
    }

    private void LaunchObject()
    {
        if (SpawnedObject != null)
        {
            SpawnedObject.transform.parent = null;
            Rigidbody BallsBody = SpawnedObject.GetComponent<Rigidbody>();
            if (BallsBody != null)
            {
                BallsBody.isKinematic = false;
                BallsBody.AddForce(transform.forward * LaunchForce, ForceMode.Impulse);
            }
            SpawnedObject = null;
            HoldingObject = false;
        }
    }
}

