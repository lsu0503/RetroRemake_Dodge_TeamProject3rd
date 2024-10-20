using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : Controller
{
    private Transform[] targetTransformArray;

    private void Start()
    {
        GameObject[] targetObjArray = GameObject.FindGameObjectsWithTag("Player");
        List<Transform> targetTransformList = new List<Transform>();

        for(int i = 0; i < targetObjArray.Length; i++)
            targetTransformList.Add(targetObjArray[i].transform);

        targetTransformArray = targetTransformList.ToArray();
    }

    public Transform SetTargetTransform()
    {
        return targetTransformArray[Random.Range(0, targetTransformArray.Length)];
    }

    protected virtual void Move()
    {

    }
}