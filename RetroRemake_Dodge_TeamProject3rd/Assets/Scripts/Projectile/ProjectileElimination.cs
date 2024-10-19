using UnityEngine;

public class ProjectileElimination : MonoBehaviour
{
    private ProjectileData data;
    private void Awake()
    {
       data = GetComponent<ProjectileData>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //이 스크립트를 붙인 오브젝트에 닿으면 투사체가 비활성화됨 
        GameObject callObj = collision.gameObject;
        ProjectileData? targetData = callObj.GetComponent<ProjectileData>();

        if (targetData != null)
        {
            if (targetData.type < 0)
                callObj.SetActive(false);
        }
    }
}
