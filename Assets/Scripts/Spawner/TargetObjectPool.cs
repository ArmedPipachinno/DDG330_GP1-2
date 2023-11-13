using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObjectPool
{
    private Normal_Target_Manager NormalTargetPref;
    private Queue<Normal_Target_Manager> BoxPoolQueue = new Queue<Normal_Target_Manager>();

    public TargetObjectPool(Normal_Target_Manager normalPref, int initialSize)
    {
        NormalTargetPref = normalPref;
        for (int i = 0; i < initialSize; i++)
        {
            Create();
        };
    }

    private void Create()
    {
        Normal_Target_Manager createNormalTarget = Object.Instantiate(NormalTargetPref);
        createNormalTarget.gameObject.SetActive(false);
        BoxPoolQueue.Enqueue(createNormalTarget);
    }

    public Normal_Target_Manager Get()
    {
        if (BoxPoolQueue.Count == 0)
        {
            Create();
        }
        Normal_Target_Manager firstFreeTarget = BoxPoolQueue.Dequeue();
        firstFreeTarget.ResetData();
        firstFreeTarget.gameObject.SetActive(true);
        return firstFreeTarget;
    }

    public void ReturnToPool(Normal_Target_Manager target)
    {
        target.gameObject.SetActive(false);
        BoxPoolQueue.Enqueue(target);
    }
}
