using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : Controller
{
    protected MonsterData data;

    private void Awake()
    {
        data = GetComponent<MonsterData>();
    }

    protected virtual void Update()
    {
        if(data.actionSelector == 0)
        {
            CallMoveEvent(Vector2.left);

            if (transform.position.x <= 5)
                data.actionSelector = 1;
        }

        if(data.actionSelector == 1)
        {
            CallMoveEvent(Vector2.right);

            if(transform.position.x >= 18)
                Destroy(gameObject);
        }
    }
}
