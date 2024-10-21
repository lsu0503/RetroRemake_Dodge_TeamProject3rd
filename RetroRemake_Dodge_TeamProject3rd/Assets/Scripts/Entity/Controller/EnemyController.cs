using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : Controller
{
    protected MonsterData data;
    public int actionSelector;
    private int[] moveDirectionOnLegion = new int[] { 1, 1 };

    private void Awake()
    {
        data = GetComponent<MonsterData>();
        if (MonsterGenerator.Instance.level >= 2)
            actionSelector = -1;
        else
            actionSelector = 0;
    }

    protected virtual void Update()
    {
        Movement();
    }

    protected virtual void Movement()
    {
        if (actionSelector == 0)
        {
            CallMoveEvent(Vector2.left);

            if (transform.position.x <= 5)
                actionSelector = 1;
        }

        else if (actionSelector == 1)
        {
            CallMoveEvent(Vector2.right);

            if (transform.position.x >= 18)
                Destroy(gameObject);
        }

        else if(actionSelector == -1)
        {
            CallMoveEvent(new Vector2(0.5f * moveDirectionOnLegion[0], 1.0f * moveDirectionOnLegion[1]).normalized);

            if (transform.position.x >= 14)
                moveDirectionOnLegion[0] = -1;

            else if (transform.position.x <= 1)
                moveDirectionOnLegion[0] = 1;

            if (transform.position.y >= 5)
                moveDirectionOnLegion[1] = -1;

            else if (transform.position.y <= -4.5)
                moveDirectionOnLegion[1] = 1;
        }
    }
}
