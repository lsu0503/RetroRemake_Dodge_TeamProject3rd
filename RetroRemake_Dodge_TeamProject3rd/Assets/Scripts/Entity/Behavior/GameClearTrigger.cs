using UnityEngine;

public class GameClearTrigger : MonoBehaviour
{
    CharacterBehavior behavior;

    private void Awake()
    {
        behavior = GetComponent<CharacterBehavior>();
    }

    private void Start()
    {
        behavior.OnDieEvent += SetGameClear;
    }

    private void SetGameClear()
    {
        StageManager.Instance.GameOver(true);
    }
}