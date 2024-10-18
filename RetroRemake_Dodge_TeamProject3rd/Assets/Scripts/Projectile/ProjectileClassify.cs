using UnityEngine;

public class ProjectileClassify : MonoBehaviour
{
    enum PLAYERNUMBER
    {
        Enemy = -1,
        Player1 = 0,
        Player2 = 1

    }

    bool isFirstTime = true;
    [SerializeField] private ProjectileData data;

    private void Awake()
    {
        data = GetComponent<ProjectileData>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isFirstTime) return;

        if (collision.gameObject.CompareTag("Enemy"))
        {

            data.type = (int)PLAYERNUMBER.Enemy;
            isFirstTime = false;
            return;
        }
        else if (collision.gameObject.CompareTag("Player1"))
        {
            data.type = (int)PLAYERNUMBER.Player1;
            isFirstTime = false;
            return;
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            data.type = (int)PLAYERNUMBER.Player2;
            isFirstTime = false;
            return;
        }
    }
}
