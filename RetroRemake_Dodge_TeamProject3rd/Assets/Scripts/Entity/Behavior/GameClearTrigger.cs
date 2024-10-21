using UnityEngine;

public class GameClearTrigger : MonoBehaviour
{
    CharacterBehavior behavior;

    private void Awake()
    {
        behavior = GetComponent<CharacterBehavior>();
    }

    private void OnDestroy()
    {
        SetGameClear();
    }

    private void SetGameClear()
    {
        StageManager.Instance.GameOver(true);
    }
}