using System.Collections.Generic;
using UnityEngine;

public class MonsterAttack : ShotBase
{
    protected MonsterData monsterData;
    protected Transform[] targetTransformArray;
    protected int actionSelector;

    [SerializeField] protected GameObject[] projPrefs;

    protected override void Awake()
    {
        base.Awake();
        monsterData = GetComponent<MonsterData>();
    }

    protected override void Start()
    {
        base.Start();

        GameObject[] targetObjArray = GameObject.FindGameObjectsWithTag("Player");
        List<Transform> targetTransformList = new List<Transform>();

        for (int i = 0; i < targetObjArray.Length; i++)
            targetTransformList.Add(targetObjArray[i].transform);

        targetTransformArray = targetTransformList.ToArray();
    }

    protected Transform SetTargetTransform()
    {
        return targetTransformArray[Random.Range(0, targetTransformArray.Length)];
    }
}