using System;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public event Action<int> OnHitEvent;
    public event Action OnDieEvent;
    public event Action OnSpawnEvent;

    public virtual bool OnHit(int damage)
    {
        CallHitEvent(damage);
        return true;
    }

    public void CallHitEvent(int damage)
    {
        OnHitEvent?.Invoke(damage);
    }

    public void CallDieEvent()
    {
        OnDieEvent?.Invoke();
    }

    public void CallSpawnEvent()
    {
        OnSpawnEvent?.Invoke();
    }
}
